using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;
namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_Layout : IRERP_SM_Canvas/* TIRERP_SM_Layout<IRERP_SM_Layout> { }
    public class TIRERP_SM_Layout <T>: TIRERP_SM_Canvas<T>
        where T: IRERPControlBase*/
        
    {
        private IRERPControlBase[] _members = null;
        public IRERPControlBase[] members { get { return _members; } set { _members = value; } }

        //public virtual T SET_members(params IRERPControlBase[] _members)
        //{
        //    this.members.Clear();
        //    this.members .AddRange( _members);
        //    return (T)(IRERPControlBase)this; 
        //}
        public virtual IRERPControlTypes_Alignment? align { get; set; }
        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (align != null) Parts.Add("align", "align:" + enum2JSON(align));
                string members = "";
                if(this.members!=null)
                    foreach (var c in this.members) members += c.ToStringAsMemberOfOther()+",";
                Parts.Add("members", "members:[" + members + "]");
                return Parts;
            }
            else
            { return new Dictionary<string,string>(); }
            
        }

        public override string ToStringAsMemberOfOther()
        {
            if (IsInInitializeTime)
                return "isc.Layout.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
            else
                return "";
        }
        public override string ToString()
        {
            if (IsInInitializeTime)
                return "isc.Layout.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
            else
                return "";
        } 
    }
}