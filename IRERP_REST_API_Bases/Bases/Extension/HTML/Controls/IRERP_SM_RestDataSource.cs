using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
  

    public class IRERP_SM_RestDataSource : IRERP_SM_DataSource
    {

        string _addDataURL;
        public string addDataURL { get { return _addDataURL; } set { if (IsInInitializeTime) _addDataURL = value; else throw NotImplementerdForIR(); } }


     

        public Nullable<bool> disableQueuing { get; set; }


        string _fetchDataURL;
        public string fetchDataURL { get { return _fetchDataURL; } set { if (IsInInitializeTime) _fetchDataURL = value; else throw NotImplementerdForIR(); } }


        string _updateDataURL ;
        public string updateDataURL  { get { return _updateDataURL ; } set { if (IsInInitializeTime) _updateDataURL  = value; else throw NotImplementerdForIR(); } }


        string _removeDataURL;
        public string removeDataURL { get { return _removeDataURL; } set { if (IsInInitializeTime) _removeDataURL = value; else throw NotImplementerdForIR(); } }

        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (addDataURL != null) Parts.Add("addDataURL", "addDataURL:" + string2JSON(addDataURL.ToString()) + "");
                if (dataFormat != null) Parts.Add("dataFormat", "dataFormat:" + string2JSON(dataFormat.ToString()) + "");
                if (updateDataURL != null) Parts.Add("updateDataURL", "updateDataURL:" + string2JSON(updateDataURL.ToString()) + "");
                if (removeDataURL != null) Parts.Add("removeDataURL", "removeDataURL:" + string2JSON(removeDataURL.ToString()) + "");
                if (fetchDataURL != null) Parts.Add("fetchDataURL", "fetchDataURL:" + string2JSON(fetchDataURL.ToString()) + "");
                if (disableQueuing != null) Parts.Add("disableQueuing", "disableQueuing:" + bool2JSON((bool)disableQueuing) + "");


                return Parts;
            }

            else
            { return new Dictionary<string, string>(); }


        }
        public override string ToStringAsMemberOfOther()
        {
            if (IsInInitializeTime)
                return "{" + string.Join(",", GetOutPutParts().Values.ToArray()) + "}";
            else
                return "";
        }
        public override string ToString()
        {
            if (IsInInitializeTime)
                return "{" + string.Join(",", GetOutPutParts().Values.ToArray()) + "};";
            else
                return "";
        }
       
    }
}