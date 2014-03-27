using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MsdLib.CSharp.BLLCore
{
    public enum ErrorType
    {
        GeneralError, 
        ValidationError,
        TransactionalError,
        /////////////////////// 200MegTraffic
        _200Meg_ValidTillPassed, //اعتبار زمانی کاربر به پایان رسیده و کاربر نمی تواند از 200 مگ استفاده کند
        _200Meg_HaveTraffic, // کاربر دارای ترافیک است و نیازی به حجم 200 مگ ندارد
        _200Meg_UsedBefore, //کاربر قبلا از این قابلیت استفاده کرده و نمی تواند مجددا استفاده کند
        _200Meg_UserHaveNoServiceInvoice, //کاربر دارای فاکتور سرویس نیست و نمی توان به او 200 مگ داد
        _200Meg_UserUsed200MegBefore, //کاربر قبلا از این امکان استفاده کرده است

        _UsrHasTimeAndTrafficToUse,//کاربر هم زمان دارد هم حجم برای استفاده پس نمی تواند از تمدید موقت استفاده کند
        _UsrHasMoreThat20Days,//کاربر بیش از 20 روز داردو بهتر است حجم خریداری کند 
        _UsrHasNotIssuedLimitCharge,//کاربر تمدید موقت تسویه نشده دارد
        _UsrHasNoServiceName,// سرویس کاربر نامشخص است
        _UsrCannotRePerformaServiceForUser,//سرویس های کاربر بگونه ای هستند که نمی توان آنها را مجدد برای کاربر صادر کرد
        _UsrHasNoServiceInvoice,//کاربر دارای فاکتور سرویس نیست و نمی توان برای او پیش فاکتور سرویس جدید صادر کر د

        WFCancelPerforma_UnknownStatus , // وضعیت پیش فاکتور نامشخص است
        WFCancelPerforma_PerformaIssuedToInvoice, //پیش فاکتور تبدیل به فاکتور شده و لغو فاکتور باید صدا زده شود 

        WFSeviceInvoiceIssue_PerformaisnotTasvieNashode, //وضعیت پیش فاکتور تسویه نشده نیست و نمی توان آنرا تسویه کرد
        WFSeviceInvoiceIssue_NotServicePerformaPassed,//پیش فاکتور ارسال شده برای تسویه پیش فاکتور سرویس نیست
        WFSeviceInvoiceIssue_PerformaHasInvoice,//پیش فاکتور قبلا فاکتور خورده است
        WFSeviceInvoiceIssue_BalanceIsNotEnough,//اعتبار ریالی برای تسویه ی پیش فاکتور کافی نیست
        WFSeviceInvoiceIssue_UserUsed200MegAndChangeHisServiceAndUserRemainingDaysNotZero,//کاربر سرویس متفاوتی برای بعد خود انتخاب کرده است در حالیکه زمان استفاده اش پایان نیفانه و 200 مگ را هم برای استفاده زده است در ایت حالت نمی توان 200 مگ را تسویه کرد زیرا کاربر مدت زمانی بیشتر از فاکتور سرویس متفاوت خود استفاده می کند

        WFTrafficInvoiceIssue_PerformaisnotTasvieNashode, //وضعیت پیش فاکتور تسویه نشده نیست و نمی توان آنرا تسویه کرد
        WFTrafficInvoiceIssue_NotTrafficPerformaPassed,//پیش فاکتور ارسال شده برای تسویه پیش فاکتور حجم نیست
        WFTrafficInvoiceIssue_PerformaHasInvoice,//پیش فاکتور قبلا فاکتور خورده است
        WFTrafficInvoiceIssue_BalanceIsNotEnough,//اعتبار ریالی برای تسویه ی پیش فاکتور کافی نیست

        BankReturned_UserACCOK_PayOffNOTOK, //حساب کاربر شارژ شده است اما عملیات تسویه ی پیش فاکتور انجام نشده است
        BankReturned_UserACCNOTOK_PayOffOK, // عملیات تسویه ی پیش فاکتور انجام شده است اما حساب کاربر شارژ نشده است
        BankReturned_UserACCNOTOK_PayOffNOTOK, // عملیات تسویه ی پیش فاکتور انجام نشده است و حساب کاربر شارژ نشده است
        BankReturned_NoPayment, //پرداختی صورت نگرفته استپ
        
        WFTrafficPerforma_UserTimeExpired,//کاربر برای حرید حجم اعتبار زمانی نداردپ
        WFTrafficPerforma_UserHasNoService,//سرویس کاربر نامشخص است
    }
    public class FunctionResult<T>
    {

        public bool Result { get; set; }
        public T ResultValue { get; set; }
        public Stack<string> Functions { get; set; }
        public PException Error { get; set; }
        public ErrorType ErrorType { get; set; }
        public DateTime Time { get; set; }
        public String FunctionName { get; set; }
        public FunctionResult()
        {
            this.Time = DateTime.Now;
            ErrorType = BLLCore.ErrorType.GeneralError;
        }

        public static implicit operator bool(FunctionResult<T> m)
        {
            return m.Result;
        }
        public static implicit operator T(FunctionResult<T> m)
        {
            return m.ResultValue;
        }
    }
}
