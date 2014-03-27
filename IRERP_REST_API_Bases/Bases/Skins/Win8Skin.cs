using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.Extension.HTML.Controls;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;
namespace IRERP_RestAPI.Bases.Skins
{
    public class Win8Skin
    {
        static string Sabz = "#6f9e10";
        static string Sorkh = "#fc4c4c";
        static string Banafsh = "#9569e5";
        static string golbehi = "#FE6F5E";
        static string Orange = "#fc854B";
        // string portletlabelbackcolor = "#888888";

        static string[] colors = { Sabz, Sorkh, Banafsh, golbehi, Orange };

        static string RandomColor()
        {
            System.Threading.Thread.Sleep(1);
            int a = (int)((new Random()).NextDouble() * (colors.Length - 1));
            return colors[a]
                ;
        }
        public static IRERP_SM_Portlet GetGeneralPortlet(string border = "1px solid", string _height = "100%", string _width = "100%",
            string _imgsrc = "/Images/1368871535_cart-empty.png", string LaBEL = " سرویس 128 kb", string _backgroundcolor = null, IRERPControlTypes_StringMethods click = null,
            string imagewidth = null, string imageheight = "*", IRERPControlTypes_imageType? _imagetype = IRERPControlTypes_imageType.center, string _baseStyle = "whitelabel", string _heightLabl = "20%",bool ShowImg=true)
        {
            if (_backgroundcolor == null) _backgroundcolor = RandomColor();
            if(ShowImg)
            return new IRERP_SM_Portlets()
            {
                click = click,
                border = border,
                members = new IRERPControlBase[]{
               new IRERP_SM_VLayout(){
                  
                    height=_height,width=_width,
                    
                    members= new IRERPControlBase[]{
                        new IRERP_SM_Img(){src=_imgsrc,imageType=_imagetype,height=imageheight,width=imagewidth,align=IRERPControlTypes_Alignment.center},
                      
                         new IRERP_SM_Label(){height=_heightLabl},
                        new IRERP_SM_Label(){
                            contents = new  IRERPControlTypes_HTMLString(LaBEL)
                            ,baseStyle=_baseStyle,align=IRERPControlTypes_Alignment.center,
                            height="10",overflow=IRERPControlTypes_Overflow.visible,width="100%"
                        },
               }
           }
        },

                showEdges = false,
                showHeader = false,
                backgroundColor = _backgroundcolor

            };
            else
                return new IRERP_SM_Portlets()
                {
                    click = click,
                    border = border,
                    members = new IRERPControlBase[]{
               new IRERP_SM_VLayout(){
                  
                    height=_height,width=_width,
                    
                    members= new IRERPControlBase[]{
                        new IRERP_SM_Label(){
                            contents = new  IRERPControlTypes_HTMLString(LaBEL)
                            ,baseStyle=_baseStyle,align=IRERPControlTypes_Alignment.center,
                            height="10",overflow=IRERPControlTypes_Overflow.visible,width="100%"
                        },
               }
           }
        },

                    showEdges = false,
                    showHeader = false,
                    backgroundColor = _backgroundcolor

                };

        }

        public static IRERP_SM_PortalLayout GetGeneralPortLayout()
        {
            return new IRERP_SM_PortalLayout()
                  {
                      showColumnMenus = false,
                      width = "100%",
                      height = "100%",
                      ID = "mainPortal",
                      canResizeColumns = false,
                      showResizeBar = false,
                      preventColumnUnderflow = false,
                      columnBorder = 0,
                      margin = 10
                  };
        }
        public static string byte2Label(long bytes)
        {
            if (
                (bytes) > Math.Pow(1024, 3)
                )

            {

                return 
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,"{0:0,0}"
                    ,
                    ((double)(bytes / Math.Pow(1024, 3))).ToString("#.#") +
                    (" گیگابایت "));

            }

            if (
    (bytes  ) > Math.Pow( 1024 , 2)
    ) 

               return  string.Format(System.Globalization.CultureInfo.GetCultureInfo("en-US"), "{0:0,0}", ((double)(bytes / Math.Pow( 1024 , 2))).ToString("#.#") )+
          

        (" مگابایت ");

            if (
    (bytes) > 1024

    ) 
                       return  string.Format(System.Globalization.CultureInfo.GetCultureInfo("en-US"), "{0:0,0}", ((double)(bytes / 1024 )).ToString("#.#") )+
               

        (" کیلوبایت ");

            return bytes.ToString() + " بایت ";


        }
        public static string ConvertNumLa2Fa(string num)
        {
            if (num == null) num = string.Empty;
            string result = string.Empty;
            foreach (char c in num.ToCharArray())
            {
                switch (c)
                {
                    case '0':
                        result += "٠";
                        break;
                    case '1':
                        result += "١";
                        break;
                    case '2':
                        result += "٢";
                        break;
                    case '3':
                        result += "٣";
                        break;
                    case '4':
                        result += "۴";
                        break;
                    case '5':
                        result += "۵";
                        break;
                    case '6':
                        result += "۶";
                        break;
                    case '7':
                        result += "٧";
                        break;
                    case '8':
                        result += "٨";
                        break;
                    case '9':
                        result += "٩";
                        break;
                    default:
                        result += c;
                        break;

                }
            }
            return result;
        }



        public static string ConvertNumLa2En(string num)
        {
            string result = string.Empty;
            foreach (char c in num.ToCharArray())
            {
                switch (c)
                {
                    case '٠':
                        result += "0";
                        break;
                    case '١':
                        result += "1";
                        break;
                    case '٢':
                        result += "2";
                        break;
                    case '٣':
                        result += "3";
                        break;
                    case '۴':
                        result += "4";
                        break;
                    case '۵':
                        result += "5";
                        break;
                    case '۶':
                        result += "6";
                        break;
                    case '٧':
                        result += "7";
                        break;
                    case '٨':
                        result += "8";
                        break;
                    case '٩':
                        result += "9";
                        break;
                    default:
                        result += c;
                        break;

                }
            }
            return result;
        }

        public static string ConvertstringLa2Fa(string text)
        {
            string result = string.Empty;
           
                switch (text)
                {
                    case "Saturday":
                        result += "شنبه";
                        break;
                    case "Sunday":
                        result += "یکشنبه";
                        break;
                    case "Monday":
                        result += "دوشنبه";
                        break;
                    case "Tuesday":
                        result += "سه شنبه";
                        break;
                    case "Wednesday":
                        result += "چهارشنبه";
                        break;
                    case "Thursday":
                        result += "پنجشنبه";
                        break;
                    case "Friday":
                        result += "جمعه";
                        break;
                  
                    default:
                        result += text;
                        break;

                
            }
            return result;
        }

        public static string GetTitle(string NameService, string Speed, string Traffic)
        {
            string a = ConvertNumLa2Fa(NameService);
            string b = ConvertNumLa2Fa(Speed);
            string c = ConvertNumLa2Fa(Traffic);
            c = " " +
            c.Replace("GB", " گیگابایت ").Trim() + " ";

            var _a = a.Trim().Split('-');
            a = "" + _a[0] + _a[1];

            return b + "---" + a + " " + "<br/>" + c;
        }


        public static string GetTrafficTitle(string Traffic)
        {

            string c = ConvertNumLa2Fa(Traffic);
            c = " " +
            c.Replace("G", " گیگابایت ").Trim() + " ";



            return c;
        }


        public static IRERP_SM_Label GetGeneralLable(string _contents = null)
        {
            return new IRERP_SM_Label()
            {
                contents = new IRERPControlTypes_HTMLString(_contents),
                baseStyle = "Blacklabel",
                align = IRERPControlTypes_Alignment.center,
                height = "10",
                overflow = IRERPControlTypes_Overflow.visible,
                width = "50%"
            };
        }

        public static IRERP_SM_ListGrid GetGeneralListGrid(string _width="100%",string _height="100%",string _backgroundcolor=null,
            bool _alternateRecordStyles=true, IRERPControlBase Datasource = null,string _baseStyle=null,
            string _bodyBackgroundColor=null,bool _autoFetchData=true,string ID=null
            )
        {
            var rtn = 
                new IRERP_SM_ListGrid()
            {
                width = _width,
                height = _height,
                backgroundColor = _backgroundcolor,
                alternateRecordStyles = _alternateRecordStyles,
                dataSource = Datasource,
                baseStyle = _baseStyle,
                bodyBackgroundColor = _bodyBackgroundColor,
                autoFetchData = _autoFetchData
            };
            if (ID != null) rtn.ID = ID;
            return rtn;
        }



       
    }
}