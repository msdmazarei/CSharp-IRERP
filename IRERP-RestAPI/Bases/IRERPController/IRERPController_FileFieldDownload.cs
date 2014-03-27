using IRERP_RestAPI.Bases.ClientEngine;
using IRERP_RestAPI.Bases.DataVirtualization;
using IRERP_RestAPI.Bases.Extension.HTML.Controls;
using IRERP_RestAPI.Bases.IRERPActionResults;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using MsdLib.CSharp.BLLCore;
using MsdLib.CSharp.DALCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRERP_RestAPI.Bases.Extension.Methods;
using MsdLib.ExtentionFuncs.Strings;
using NHibernate;
namespace IRERP_RestAPI.Bases.IRERPController
{
    partial class IRERPController : Controller
    {
        public virtual IRERPMethodActionResult FileFieldDownloadMethod(ClientEngineDataCarrier reqFileDownload)
        {
            var rtn = new IRERPMethodActionResult();
            string FileProperty = Members[0];
            IRERPProfile profile = IRERPApplicationUtilities.GetProfileFromString(Members[1]);
            string fullpropertypath = string.Join(".", Members, 2, Members.Length - 2);
            string[] members = fullpropertypath.Split('.');
            string[] MasterMembers = new string[members.Length - 1];
            Array.Copy(members, MasterMembers, MasterMembers.Length);

            //Get Sent Profile
            IRERPProfile prof =
                IRERPApplicationUtilities.GetMemberPropertyTypeProfile(
                this.MetaModelInstance.GetType(),
                profile,
                MasterMembers);

            Type TargetType =
                IRERPApplicationUtilities
                .GetClassPropertyType(MetaModelInstance.GetType(), MasterMembers);

            var validator = IRERPApplicationUtilities.Get_ValidateDescriptors_ByModelAndProfile(TargetType, prof);
            //getid
            Guid id = IRERPApplicationUtilities.GetHttpParameter("id") != null ? 
                Guid.Parse(IRERPApplicationUtilities.GetHttpParameter("id")) 
                : Guid.Empty;
            if (id != Guid.Empty)
            {
                string filepath = FileManager.getUploadPath() + id.ToString();
                if (!System.IO.File.Exists(filepath))
                    filepath = FileManager.getTempUploadPath() + id.ToString();
                if (!System.IO.File.Exists(filepath))
                    return null;
                
            }

            return rtn;
        }


    }

}
