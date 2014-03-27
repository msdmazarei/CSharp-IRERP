using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.MetaDataDescriptors
{
    public enum 
        IRERPProfile : ulong
    {
        Unknown=0,
        Any=1,
        General=2,
        Detail=3,
        Abstract=4,

        //==========================
        //====== Invoice Profiles
        Invoice_OverView,
        //==========================

          //==========================
        //====== Support User
        SupportUser_Overview,
        SupportOperator_Overview,
        SupportUser_Overview_Detail,
        //==========================

        //==============================
        InvoiceUser_overview,
       RealInvoice_OverView,

        namayandeganForosh_overview,
       // //================================

       Performa_General,
        LegalCharacter_General,
        CharacterAgent,

        DO_General,
        DO_ViewSales,
        D_ViewFeasibility,
        D_Contract,
        DDl_OrderType,
        DDl_Building,
        DDl_Character,
        DDl_Service,
        DDl_priceAddition,

        D_CallInfo,
        D_postalAddress,
        D_MessagingInfo,
        D_RolesOfCharacter,

        B_RightFulCharacter,
        B_LegalCharacter,
        B_Dependent,
        B_Building,
        B_Building_Equipment,
        B_Building_Users,
        B_Building_UserFree,
        AllServe_user,
        AllUser_Serve,
        Serve_ServeNote,
        AllServe_Date,
        AllServe_Damage,
        UserSupport,
        AllIpDateRangeIpAssingned,

        SaleRezerv,
        InstallReport,
        UserSale,
        UserFinancial,
        UserFinancial_Deposit,



        User_ActiveSesion,

        SettlementFactorsReport,
        PaidReport,
        ReservationReport,

        UserTrafficReport,
        ReservationReport_Report,
        InstallReport2,
        ServicesReportProfile,
        InternetServices,
        AllReserveReport



      

    }
  
}