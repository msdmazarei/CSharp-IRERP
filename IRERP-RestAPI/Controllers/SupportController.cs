
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRERP_RestAPI.Bases.IRERPController;
using IRERP_RestAPI.MetaModel;
using IRERP_RestAPI.Models;
using IRERP_RestAPI.Bases;

namespace IRERP_RestAPI.Controllers
{
    public class SupportController : IRERPController<Support_MetaModel>
    {
        //public override void InitControllerSessionValues()
        //{
        //    base.InitControllerSessionValues();
        //    var req = IRERP_RestAPI.Bases.ClientEngine.ClientEngineDataCarrier.ClientRequest();
        //    if(req.type == Bases.ClientEngine.ClientEngineDataCarrierType.fetch)
        //    {
        //        var crit = (
        //            (
        //            (Bases.ClientEngine.FetchRequest)req
        //            ).GetCriteriaByPropName(
        //            "_" + IRERPApplicationUtilities.GPN<Support_MetaModel>(x => x.SelectedUser.UserID)
        //            )
        //            );
        //        if (crit != null)
        //            IRERPApplicationUtilities.SaveToSession<Support_MetaModel, User>(x =>x.SelectedUser, crit.value);
        //        else
        //            IRERPApplicationUtilities.SaveToSession<Support_MetaModel, User>(
        //                x => x.SelectedUser,
        //            IRERPApplicationUtilities.GetHttpParameter("_" + IRERPApplicationUtilities.GPN<Support_MetaModel>(x => x.SelectedUser.UserID).Replace(".","___"))
        //            );
        //        var crit1 = (
        //         (
        //         (Bases.ClientEngine.FetchRequest)req
        //         ).GetCriteriaByPropName(
        //         "_" + IRERPApplicationUtilities.GPN<Support_MetaModel>(x => x.SelecteUserFilter.UserID)
        //         )
        //         );
        //        if (crit1 != null)
        //            IRERPApplicationUtilities.SaveToSession<Support_MetaModel, User>(x => x.SelecteUserFilter, crit.value);
        //        else
        //            IRERPApplicationUtilities.SaveToSession<Support_MetaModel, User>(
        //                x => x.SelecteUserFilter,
        //            IRERPApplicationUtilities.GetHttpParameter("_" + IRERPApplicationUtilities.GPN<Support_MetaModel>(x => x.SelecteUserFilter.UserID).Replace(".", "___"))
        //            );
        //        }
            

        //    //Remove gholikhan From Parameters
            
        //}
        
        //
        // GET: /Support/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Support()
        {

            return View(TypedMetaModelInstance);
        }

        public ActionResult testListGridFields()
        {

            return View(TypedMetaModelInstance);
        }
        public ActionResult AllServe()
        {

            return View(TypedMetaModelInstance);
        }
    }
}
