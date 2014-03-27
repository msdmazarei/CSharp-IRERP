using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Reflection;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using IRERP_RestAPI.Bases.Attribute.ProfileBase;
using FluentNHibernate.Testing.Values;
using MsdLib.CSharp.BLLCore;

using System.Data.Common;
using System.Text;
namespace IRERP_RestAPI.Bases
{




    public class IRERPApplicationUtilities : MsdLib.CSharp.Utils.AppUtils
    {

      
        public static MsdLog Logger()
        {
            const string Loggerkey = "____SYSTEMWIDE_LOGGER__";
            if (HttpContext.Current.Items.Contains(Loggerkey))
                return (MsdLog)HttpContext.Current.Items[Loggerkey];
            else
            {
                HttpContext.Current.Items.Add(Loggerkey, new MsdLog());
                return (MsdLog)HttpContext.Current.Items[Loggerkey];
            }
        }

        public static void LOG(string str)
        {
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream("msdlog.log", System.IO.FileMode.OpenOrCreate);
                fs.Seek(fs.Length, System.IO.SeekOrigin.Begin);
                byte[] buf = System.Text.Encoding.Unicode.GetBytes(str);

                fs.Write(buf, 0, buf.Length);
                fs.Close();
            }
            catch
            {
            }
        }

        /// <summary>
        /// چک می کند که تا آخرین قسمت از مسیر دارای مقدار باشد در صورتی که در وسط مسیر
        /// تهی شد عدم موفقیت را بر می گرداند
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="sourceValue"></param>
        /// <returns></returns>
        public static bool HasValueTillLastStep<T1>(T1 sourceValue,Expression<Func<T1,object>> path)
        {
            object src = sourceValue;
           string[] pathparts = GPN<T1>(path).Split('.');
            for (var i = 0; i < pathparts.Length; i++)
            {
                src = GetProperty(src, pathparts[i]);
                if (src == null)
                    return false;
            }
            
            return true;
        }

        public static object GetRandomValue(Type t)
        {
            
            if (t == typeof(int)) return (new Random()).Next();
            if (t == typeof(long)) return (new Random()).Next();
            if (t == typeof(double)) return (new Random()).NextDouble() * 1e7;
            byte[] buf = new byte[10];
            if (t == typeof(string))
            {
                (new Random()).NextBytes(buf);
                return System.Text.ASCIIEncoding.ASCII.GetString(buf);
            }
            if (t == typeof(DateTime)) return DateTime.Now.AddDays((new Random()).NextDouble() * 100);
            if (t == typeof(Guid)) return Guid.NewGuid();
            return null;
        }
        public static bool IsNHProxyObject(object obj)
        {
            return obj is NHibernate.Proxy.INHibernateProxy;
        }
        public static Type GetTypeFromString(string typename)
        {
            Type rtn = null;
            rtn = Type.GetType(typename);
            if (rtn == null)
            {
                AppDomain.CurrentDomain.GetAssemblies().ToList().ForEach(
                    x =>
                    {
                        if (rtn != null)
                            return;
                        rtn = x.GetType(typename);
                    }
                );
            }
            return rtn;
        }

        public static void SessionParameters<TMetaModel>(Expression<Func<TMetaModel, object>> path)
        {
            var req = IRERP_RestAPI.Bases.ClientEngine.ClientEngineDataCarrier.ClientRequest();
            MsdCriteria crit = null;
            if (req.type == Bases.ClientEngine.ClientEngineDataCarrierType.fetch)
            {
                crit = (
                    (
                    (Bases.ClientEngine.FetchRequest)req
                    ).GetCriteriaByPropName(
                    "_" + IRERPApplicationUtilities.GPN<TMetaModel>(path)
                    )
                    );
            }
            if (crit != null)
                IRERPApplicationUtilities.SaveToSession<TMetaModel>(path, crit.value);
            else
                if (
                    IRERPApplicationUtilities.GetHttpParameter("_" + IRERPApplicationUtilities.GPN<TMetaModel>(path).Replace(".", "___"))
                    != null)
                    IRERPApplicationUtilities.SaveToSession<TMetaModel>(
                        path,
                    IRERPApplicationUtilities.GetHttpParameter("_" + IRERPApplicationUtilities.GPN<TMetaModel>(path).Replace(".", "___"))
                    );

            // }
        }
        public new static void SetProperty(object Obj, string PropName, object Value, bool recursive = true)
        {
            if (PropName.IndexOf(".") < 0)
                MsdLib.CSharp.Utils.AppUtils.SetProperty(Obj, PropName, Value, recursive);
            else
            {
                object oj = Obj;
                string[] proppath = PropName.Split('.');
                for (int i = 0; i < proppath.Length - 1; i++)
                {
                    string CurPropName = proppath[i];
                    if (IRERPApplicationUtilities.GetProperty(oj, CurPropName) != null)
                    {
                        oj = IRERPApplicationUtilities.GetProperty(oj, CurPropName);
                        continue;
                    }
                    else
                    {
                        Type CurPropType = null;
                        if (proppath[proppath.Length - 1] == CurPropName)
                        {
                            CurPropType = IRERPApplicationUtilities.GetClassPropertyType(oj.GetType(), CurPropName);
                            object CurPropInstance = IRERPApplicationUtilities.NewInstance(CurPropType);
                            IRERPApplicationUtilities.SetProperty(oj, CurPropName, CurPropInstance);
                        }
                        else
                        {
                            //Intermediate property is null
                            return;
                        }
                    }
                }
                IRERPApplicationUtilities.SetProperty(oj, proppath[proppath.Length - 1], Value);
            }



        }
        public static string GetFromSession<T>(Expression<Func<T, object>> expr)
        {
            return GetFromSession<T, object>(expr);
        }
        public static string GetFromSession<T, Tout>(Expression<Func<T, Tout>> expr)
        {
            string varname = typeof(T).Name.ToString() + "_" + typeof(Tout).Name.ToString() + expr.Body.ToString();
            var a = HttpContext.Current.Session[varname];
            if (a != null) return a.ToString();
            return null;
        }
        public static string ControlId(System.Web.Mvc.Controller controller, string Id)
        {
            return "_" + controller.GetHashCode().ToString() + System.Web.HttpContext.Current.Request.GetHashCode().ToString() + "_" + Id;
        }
        public static void RemoveFromClient(string key)
        {
            if (GetFromClient(key) != null)
            {
                HttpCookie myCookie = new HttpCookie(key);
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                HttpContext.Current.Response.Cookies.Add(myCookie);
            }
        }
        public static void RemoveFromSession(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }
        public static object GetFromSession(string key)
        {
            try
            {
                return HttpContext.Current.Session[key];
            }
            catch
            {
                return null;
            }

        }
        public static void SaveToSession(string key, object Value)
        {
            bool exists = false;
            foreach (string k in HttpContext.Current.Session.Keys)
                if (k == key) { exists = true; break; }
            if (exists)
                HttpContext.Current.Session[key] = Value;
            else
                HttpContext.Current.Session.Add(key, Value);
        }
        public static void SaveToClient(string key, string value)
        {
            HttpCookie tmp = new HttpCookie(key, value);
            HttpContext.Current.Response.Cookies.Add(tmp);
        }
        public static string GetFromClient(string key)
        {
            if (HttpContext.Current.Request.Cookies.AllKeys.Contains(key))
                return HttpContext.Current.Request.Cookies[key].Value;
            return null;
        }
        public static void SaveToSession<T, Tout>(Expression<Func<T, Tout>> expr, string value)
        {
            string varname = typeof(T).Name.ToString() + "_" + typeof(Tout).Name.ToString() + expr.Body.ToString();
            if (GetFromSession(expr) == null)
                HttpContext.Current.Session.Add(varname, value);
            else
                HttpContext.Current.Session[varname] = value;

        }
        public static void RequestParameters<TMetaModel>(Expression<Func<TMetaModel, object>> path)
        {
            var req = IRERP_RestAPI.Bases.ClientEngine.ClientEngineDataCarrier.ClientRequest();
            MsdCriteria crit = null;
            if (req.type == Bases.ClientEngine.ClientEngineDataCarrierType.fetch)
            {
                crit = (
                    (
                    (Bases.ClientEngine.FetchRequest)req
                    ).GetCriteriaByPropName(
                    "_" + IRERPApplicationUtilities.GPN<TMetaModel>(path)
                    )
                    );
            }
            if (crit != null)
                IRERPApplicationUtilities.SaveToRequest<TMetaModel>(path, crit.value);
            else
                if (
                    IRERPApplicationUtilities.GetHttpParameter("_" + IRERPApplicationUtilities.GPN<TMetaModel>(path).Replace(".", "___"))
                    != null)
                    IRERPApplicationUtilities.SaveToRequest<TMetaModel>(
                        path,
                    IRERPApplicationUtilities.GetHttpParameter("_" + IRERPApplicationUtilities.GPN<TMetaModel>(path).Replace(".", "___"))
                    );

        }
        public static void SaveToRequest<T>(Expression<Func<T, object>> expr, string value)
        {
            if (HttpContext.Current.Items.Contains(GPN<T>(expr)))
            {
                HttpContext.Current.Items[GPN<T>(expr)] = value;
            }
            else
            {
                HttpContext.Current.Items.Add(GPN<T>(expr), value);
            }
        }
        public static string GetFromRequest<T>(Expression<Func<T, object>> expr)
        {
            if (HttpContext.Current.Items.Contains(GPN<T>(expr)))
            {
                return (string)HttpContext.Current.Items[GPN<T>(expr)] ;
            }
            else
            {
                return null;
            }
        }
        public static void SaveToSession<T>(Expression<Func<T, object>> expr, string value)
        {
            SaveToSession<T, object>(expr, value);
        }

        /******
         * input : User,Detail,SMSes
         * output : returns petiak_wifi_sms profile which defined to User type Detail Profile
         * */
        public static IRERPProfile GetMemberPropertyTypeProfile(Type StartType, IRERPProfile StartTypeProfile, string[] MemberPath)
        {
            IRERPProfile rtn = StartTypeProfile;
            foreach (var member in MemberPath)
            {
                List<MemberInfo> useasprofilemembers = null;
                var tyname = new IRERPTypeName(StartType);
                if (!IRERPDescriptorVars.STOREUseAsProfile.Keys.Contains(tyname))
                    return IRERPProfile.Unknown;
                if (IRERPDescriptorVars.STOREUseAsProfile[tyname].Keys.Contains(rtn))
                {
                    useasprofilemembers = IRERPDescriptorVars.STOREUseAsProfile[tyname][rtn].Keys.ToList();
                }
                if (IRERPDescriptorVars.STOREUseAsProfile[tyname].Keys.Contains(IRERPProfile.Any))
                {
                    if (useasprofilemembers == null)
                        useasprofilemembers = IRERPDescriptorVars.STOREUseAsProfile[tyname][IRERPProfile.Any].Keys.ToList();
                    else
                        useasprofilemembers.AddRange(IRERPDescriptorVars.STOREUseAsProfile[tyname][IRERPProfile.Any].Keys.ToList());
                }



                var validmemberkeys = (from x in useasprofilemembers
                                       where
                                           x.Name == member
                                       select x
                                        ).ToList();
                if (validmemberkeys.Count < 1)
                    return IRERPProfile.Unknown;
                StartType = ((PropertyInfo)validmemberkeys[0]).PropertyType;

                if (
                    IRERPDescriptorVars.STOREUseAsProfile[tyname].Keys.Contains(rtn)//.Keys.Contains(validmemberkeys[0])
                    )
                {
                    if (IRERPDescriptorVars.STOREUseAsProfile[tyname][rtn].Keys.Contains(validmemberkeys[0]))
                        rtn = IRERPDescriptorVars.STOREUseAsProfile[tyname][rtn][validmemberkeys[0]].TargetProfile;
                    else if (IRERPDescriptorVars.STOREUseAsProfile[tyname][IRERPProfile.Any].Keys.Contains(validmemberkeys[0]))
                        rtn = IRERPDescriptorVars.STOREUseAsProfile[tyname][IRERPProfile.Any][validmemberkeys[0]].TargetProfile;

                }

                else if (IRERPDescriptorVars.STOREUseAsProfile[tyname][IRERPProfile.Any].Keys.Contains(validmemberkeys[0]))

                    rtn = IRERPDescriptorVars.STOREUseAsProfile[tyname][IRERPProfile.Any][validmemberkeys[0]].TargetProfile;
            }


            return rtn;
        }
        public static Dictionary<MemberInfo, DSFieldProperty> GetDSFieldPropetyByModelAndProfile(Type Model, IRERPProfile Profile)
        {

            Dictionary<MemberInfo, DSFieldProperty> rtn = new Dictionary<MemberInfo, DSFieldProperty>();
            var tyname = new IRERPTypeName(Model);

            if (
                !
                IRERPDescriptorVars.STOREDSFieldProperty.Keys.Contains(tyname)
                )
                return rtn;

            if (
                IRERPDescriptorVars.STOREDSFieldProperty[tyname].Keys.Contains(Profile)
                )
                rtn = (IRERPDescriptorVars.STOREDSFieldProperty[tyname][Profile]);

            if (IRERPDescriptorVars.STOREDSFieldProperty[tyname].Keys.Contains(IRERPProfile.Any))
            {
                //Check That Mmeber did not Add before 
                var a = (
                    from x
                    in IRERPDescriptorVars.STOREDSFieldProperty[tyname][IRERPProfile.Any].Keys
                    where
                    !rtn.Keys.Contains(x)
                    select x).ToList();
                foreach (var b in a)
                    rtn.Add(b, IRERPDescriptorVars.STOREDSFieldProperty[tyname][IRERPProfile.Any][b]);
            }

            return rtn;

        }
        public static Dictionary<MemberInfo, UseAsProfile> Get_DSUseAsProfile_Fields_ByModelAndProfile(Type Model, IRERPProfile Profile)
        {

            Dictionary<MemberInfo, UseAsProfile> rtn = new Dictionary<MemberInfo, UseAsProfile>();
            var tyname = new IRERPTypeName(Model);

            if (
                !
                IRERPDescriptorVars.STOREUseAsProfile.Keys.Contains(tyname)
                )
                return rtn;

            if (
                IRERPDescriptorVars.STOREUseAsProfile[tyname].Keys.Contains(Profile)
                )
                rtn = (IRERPDescriptorVars.STOREUseAsProfile[tyname][Profile]);

            if (IRERPDescriptorVars.STOREUseAsProfile[tyname].Keys.Contains(IRERPProfile.Any))
            {
                //Check That Mmeber did not Add before 
                var a = (
                    from x
                    in IRERPDescriptorVars.STOREUseAsProfile[tyname][IRERPProfile.Any].Keys
                    where
                    !rtn.Keys.Contains(x)
                    select x).ToList();
                foreach (var b in a)
                    rtn.Add(b, IRERPDescriptorVars.STOREUseAsProfile[tyname][IRERPProfile.Any][b]);
            }

            return rtn;

        }
        public static Dictionary<MemberInfo, Validate> Get_ValidateDescriptors_ByModelAndProfile(Type Model, IRERPProfile Profile){
            Dictionary<MemberInfo, Validate> rtn = new Dictionary<MemberInfo, Validate>();
            var tyname = new IRERPTypeName(Model);

            if (
                !
                IRERPDescriptorVars.STOREValidate.Keys.Contains(tyname)
                )
                return rtn;

            if (
                IRERPDescriptorVars.STOREValidate[tyname].Keys.Contains(Profile)
                )
                rtn = (IRERPDescriptorVars.STOREValidate[tyname][Profile]);

            if (IRERPDescriptorVars.STOREValidate[tyname].Keys.Contains(IRERPProfile.Any))
            {
                //Check That Mmeber did not Add before 
                var a = (
                    from x
                    in IRERPDescriptorVars.STOREValidate[tyname][IRERPProfile.Any].Keys
                    where
                    !rtn.Keys.Contains(x)
                    select x).ToList();
                foreach (var b in a)
                    rtn.Add(b, IRERPDescriptorVars.STOREValidate[tyname][IRERPProfile.Any][b]);
            }

            return rtn;
        }
        public static string PhysicalApplicationPath()
        {
            return HttpContext.Current.Request.PhysicalApplicationPath;
        }
        public static string GetHtmlLabelString(object control, object view, string Title)
        {
            return
                ApplicationStatics.T(Title)
    ;

        }

        // Input: x=>x.a.b.c.d
        //output {a,b,c,d}
        public static IList<string> SplitPropertiesInExpression<T, Tout>(Expression<Func<T, Tout>> expr)
        {
            List<string> rtn = new List<string>();
            rtn.AddRange(expr.Body.ToString().Split('.'));
            rtn.RemoveAt(0);
            return rtn;
        }
        public static Type GetClassPropertyType(Type starttype, string propertyname)
        {
            if (propertyname.IndexOf(".") > -1)
            {
                string[] parts = propertyname.Split('.');
                return GetClassPropertyType(starttype, parts);
            }
            var rtn = starttype.GetProperty(propertyname);
            if (rtn != null) return
                   rtn.PropertyType;

            return null;
        }

        //Input: Type1,a.b.c.d
        //return type of "d"
        public static Type GetClassPropertyType(Type starttype, string[] Propertypath)
        {
            Type rtntype = starttype;
            foreach (var mem in Propertypath)
            {
                var r1 = GetClassPropertyType(rtntype, mem);
                while (r1 == null && rtntype != null) // To Check if rtntype is IList<A> replace rtntype with A 
                {
                    if (r1 == null)
                        if (IRERPApplicationUtilities.IsSubclassOfRawGeneric(typeof(IList<>), rtntype))
                            rtntype = IRERPApplicationUtilities.GetGenericTypeConstructor(rtntype, 0);
                        else break;
                    r1 = GetClassPropertyType(rtntype, mem);
                }
                rtntype = r1;
                if (rtntype != null) continue;
                break;
            }
            return rtntype;



        }
        public static String GetClientIP()
        {
            String ip =
                HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return ip;
        }

        public static MemberInfo GetClassMember(Type Type, string MemberName)
        {
            if (MemberName != null)
                if (MemberName.IndexOf(".") > -1)
                {
                    string[] _members = MemberName.Split('.');
                    Type = GetClassPropertyType(Type, string.Join(".", _members, 0, _members.Length - 1));
                    MemberName = _members[_members.Length - 1];
                }
            var members = Type.GetMember(MemberName);
            if (members != null)
                if (members.Length > 0)
                    return members[0];
            return null;

        }
        public static MemberInfo GetClassMember<T, TOUT>(Expression<Func<T, TOUT>> expr)
        {
            Expression tmpexpr = (LambdaExpression)expr;
            while (tmpexpr.NodeType == ExpressionType.Lambda) tmpexpr = (((LambdaExpression)tmpexpr).Body);
            while (tmpexpr.NodeType == ExpressionType.Convert) tmpexpr = ((UnaryExpression)tmpexpr).Operand;
            if (tmpexpr.NodeType == ExpressionType.MemberAccess) return ((MemberExpression)tmpexpr).Member;

            return null;
        }
        public static MemberInfo GetClassMember<T>(Expression<Func<T, object>> expr)
        {
            Expression tmpexpr = (LambdaExpression)expr;
            while (tmpexpr.NodeType == ExpressionType.Lambda) tmpexpr = (((LambdaExpression)tmpexpr).Body);
            while (tmpexpr.NodeType == ExpressionType.Convert) tmpexpr = ((UnaryExpression)tmpexpr).Operand;
            if (tmpexpr.NodeType == ExpressionType.MemberAccess) return ((MemberExpression)tmpexpr).Member;

            return null;
        }
        public static string GetPropertyName(Expression<Func<object, Object>> exp)
        {
            return exp.Body.ToString();
        }

        public static string GetHtmlString<T>(T Model, Expression<Func<T, string>> expr, string Pre = null, string Post = null)
        {
            string rtn = "";
            if (Pre != null) rtn = Pre + ":";

            var value = expr.Compile()(Model);
            rtn += value;

            if (Post != null)
                rtn += " " + Post;


            return rtn;
        }


        public static string GetHtmlString<T>(T Model, Expression<Func<T, int?>> expr, string Pre = null, string Post = null)
        {
            string rtn = "";
            if (Pre != null) rtn = Pre + ":";

            var value = expr.Compile()(Model);
            rtn += ((int)value).ToString();

            if (Post != null)
                rtn += " " + Post;


            return rtn;
        }
        public static string GetHtmlString<T>(T Model, Expression<Func<T, DateTime?>> expr, string Pre = null, string Post = null)
        {
            string rtn = "";

            if (Pre != null) rtn = Pre + ":";

            var value = expr.Compile()(Model);
            if (value == null) return rtn;

            if (value != null) rtn += ((DateTime)value).ToString("yyyy/mm/dd");


            if (Post != null)
                rtn += " " + Post;


            return rtn;
        }

        public static string ToJson(object obj)
        {
            if (obj != null)
            {
                if (obj is MsdLib.CSharp.Types.PersianDateTime)
                    obj = obj.ToString();
                /*  if (IsSubclassOfRawGeneric(typeof(DBVar<>), obj.GetType()))
                  {
                      dynamic o = obj;
                      obj = o.value;
                  }*/
                return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            }
            else return "null";
        }

        public static string GetHttpParameter(string ParameterName)
        {
            string rtn = System.Web.HttpContext.Current.Request[ParameterName];
            return rtn;
        }

        public static bool IsMemberImplementedIListFamilyInterfaces(MemberInfo meminfo)
        {
            var type = ((System.Reflection.PropertyInfo)(meminfo)).PropertyType;
            foreach (Type interfaceType in type.GetInterfaces())
            {
                if (interfaceType.IsGenericType &&
                 (interfaceType.GetGenericTypeDefinition() == typeof(IList<>)
                 ||
                 interfaceType.GetGenericTypeDefinition() == typeof(ICollection<>)
                 ||
                 interfaceType.GetGenericTypeDefinition() == typeof(Array)
                 )
                    )
                    return true;
            }
            return false;

        }


        public static Type GetMemberTypeWithoutInterfaces(MemberInfo meminfo)
        {
            var type = ((System.Reflection.PropertyInfo)(meminfo)).PropertyType;

            Type itemType = null;
            foreach (Type interfaceType in type.GetInterfaces())
            {
                if (interfaceType.IsGenericType &&
                    (interfaceType.GetGenericTypeDefinition() == typeof(IList<>)
                    ||
                    interfaceType.GetGenericTypeDefinition() == typeof(ICollection<>)
                    )

                    )
                {
                    itemType = type.GetGenericArguments()[0];
                    // do something...
                    break;
                }
            }
            return itemType;
        }

        public static IRERPProfile GetProfileFromString(string str)
        {
            IRERPProfile Profile = IRERPProfile.Unknown;
            if (str == IRERPProfile.Abstract.ToString()) Profile = IRERPProfile.Abstract;
            if (str == IRERPProfile.Any.ToString()) Profile = IRERPProfile.Any;
            if (str == IRERPProfile.Detail.ToString()) Profile = IRERPProfile.Detail;
            if (str == IRERPProfile.General.ToString()) Profile = IRERPProfile.General;
            if (str == IRERPProfile.Invoice_OverView.ToString()) Profile = IRERPProfile.Invoice_OverView;
            if (str == IRERPProfile.SupportUser_Overview.ToString()) Profile = IRERPProfile.SupportUser_Overview;
            if (str == IRERPProfile.RealInvoice_OverView.ToString()) Profile = IRERPProfile.RealInvoice_OverView;
            if (str == IRERPProfile.namayandeganForosh_overview.ToString()) Profile = IRERPProfile.namayandeganForosh_overview;
            if (str == IRERPProfile.LegalCharacter_General.ToString()) Profile = IRERPProfile.LegalCharacter_General;

            if (str == IRERPProfile.DO_General.ToString()) Profile = IRERPProfile.DO_General;
            if (str == IRERPProfile.DO_ViewSales.ToString()) Profile = IRERPProfile.DO_ViewSales;
            if (str == IRERPProfile.D_ViewFeasibility.ToString()) Profile = IRERPProfile.D_ViewFeasibility;
            if (str == IRERPProfile.D_Contract.ToString()) Profile = IRERPProfile.D_Contract;

            if (str == IRERPProfile.DDl_OrderType.ToString()) Profile = IRERPProfile.DDl_OrderType;
            if (str == IRERPProfile.DDl_Building.ToString()) Profile = IRERPProfile.DDl_Building;
            if (str == IRERPProfile.DDl_Character.ToString()) Profile = IRERPProfile.DDl_Character;
            if (str == IRERPProfile.DDl_Service.ToString()) Profile = IRERPProfile.DDl_Service;
            if (str == IRERPProfile.DDl_priceAddition.ToString()) Profile = IRERPProfile.DDl_priceAddition;

            if (str == IRERPProfile.D_CallInfo.ToString()) Profile = IRERPProfile.D_CallInfo;
            if (str == IRERPProfile.D_postalAddress.ToString()) Profile = IRERPProfile.D_postalAddress;
            if (str == IRERPProfile.D_MessagingInfo.ToString()) Profile = IRERPProfile.D_MessagingInfo;
            if (str == IRERPProfile.D_RolesOfCharacter.ToString()) Profile = IRERPProfile.D_RolesOfCharacter;

            if (str == IRERPProfile.B_RightFulCharacter.ToString()) Profile = IRERPProfile.B_RightFulCharacter;
            if (str == IRERPProfile.B_LegalCharacter.ToString()) Profile = IRERPProfile.B_LegalCharacter;
            if (str == IRERPProfile.B_Building.ToString()) Profile = IRERPProfile.B_Building;
            if (str == IRERPProfile.B_Building_Equipment.ToString()) Profile = IRERPProfile.B_Building_Equipment;
            if (str == IRERPProfile.B_Building_UserFree.ToString()) Profile = IRERPProfile.B_Building_UserFree;
            if (str == IRERPProfile.B_Building_Users.ToString()) Profile = IRERPProfile.B_Building_Users;
            if (str == IRERPProfile.AllServe_user.ToString()) Profile = IRERPProfile.AllServe_user;
            if (str == IRERPProfile.AllUser_Serve.ToString()) Profile = IRERPProfile.AllUser_Serve;
            if (str == IRERPProfile.Serve_ServeNote.ToString()) Profile = IRERPProfile.Serve_ServeNote;
            if (str == IRERPProfile.AllServe_Date.ToString()) Profile = IRERPProfile.AllServe_Date;
            if (str == IRERPProfile.UserSupport.ToString()) Profile = IRERPProfile.UserSupport;
            if (str == IRERPProfile.AllIpDateRangeIpAssingned.ToString()) Profile = IRERPProfile.AllIpDateRangeIpAssingned;

            if (str == IRERPProfile.SaleRezerv.ToString()) Profile = IRERPProfile.SaleRezerv;
            if (str == IRERPProfile.InstallReport.ToString()) Profile = IRERPProfile.InstallReport;
            if (str == IRERPProfile.UserSale.ToString()) Profile = IRERPProfile.UserSale;
            if (str == IRERPProfile.UserFinancial.ToString()) Profile = IRERPProfile.UserFinancial;
            if (str == IRERPProfile.UserFinancial_Deposit.ToString()) Profile = IRERPProfile.UserFinancial_Deposit;

            if (str == IRERPProfile.SaleRezerv.ToString()) Profile = IRERPProfile.SaleRezerv;
            if (str == IRERPProfile.InstallReport.ToString()) Profile = IRERPProfile.InstallReport;
            if (str == IRERPProfile.UserSale.ToString()) Profile = IRERPProfile.UserSale;
            if (str == IRERPProfile.UserFinancial.ToString()) Profile = IRERPProfile.UserFinancial;
            if (str == IRERPProfile.UserFinancial_Deposit.ToString()) Profile = IRERPProfile.UserFinancial_Deposit;

            if (str == IRERPProfile.User_ActiveSesion.ToString()) Profile = IRERPProfile.User_ActiveSesion;

            if (str == IRERPProfile.SettlementFactorsReport.ToString()) Profile = IRERPProfile.SettlementFactorsReport;
            if (str == IRERPProfile.PaidReport.ToString()) Profile = IRERPProfile.PaidReport;
            if (str == IRERPProfile.ReservationReport.ToString()) Profile = IRERPProfile.ReservationReport;
            if (str == IRERPProfile.UserTrafficReport.ToString()) Profile = IRERPProfile.UserTrafficReport;
            if (str == IRERPProfile.ReservationReport_Report.ToString()) Profile = IRERPProfile.ReservationReport_Report;
            if (str == IRERPProfile.InstallReport2.ToString()) Profile = IRERPProfile.InstallReport2;
            if (str == IRERPProfile.ServicesReportProfile.ToString()) Profile = IRERPProfile.ServicesReportProfile;
            if (str == IRERPProfile.InternetServices.ToString()) Profile = IRERPProfile.InternetServices;
            if (str == IRERPProfile.AllReserveReport.ToString()) Profile = IRERPProfile.AllReserveReport;
            
            return Profile;
            
        }

        public static string ConvertNumLa2En(string num)
        {
            string result = string.Empty;
            foreach (char c in num.ToCharArray())
            {
                switch ((int)c)
                {
                    case 1776:
                        result += "0";
                        break;
                    case 1777:
                        result += "1";
                        break;
                    case 1778:
                        result += "2";
                        break;
                    case 1779:
                        result += "3";
                        break;
                    case 1780:
                        result += "4";
                        break;
                    case 1781:
                        result += "5";
                        break;
                    case 1782:
                        result += "6";
                        break;
                    case 1783:
                        result += "7";
                        break;
                    case 1784:
                        result += "8";
                        break;
                    case 1785:
                        result += "9";
                        break;
                    default:
                        result += c;
                        break;

                }
            }
            return result;
        }
        public static void RemoveAllKeysStartWith(string StartWith, ref Dictionary<string, string> Dic)
        {
            List<string> KeysToRemove = new List<string>();
            foreach (string key in Dic.Keys)
                if (key.IndexOf(StartWith) == 0)
                    KeysToRemove.Add(key);
            foreach (string k in KeysToRemove)
                Dic.Remove(k);
        }


    }
}