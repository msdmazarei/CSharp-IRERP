using IRERP_RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases
{
    public class InstanceStatics : ApplicationStatics
    {
        //[ThreadStatic]
        //static User _loggeduser = null;
        const string userid = "_________SESS____COOK_____USERID";
        const string logggeduser = "_______LOGGEDUSER";
        public static void logout()
        {
            IRERPApplicationUtilities.RemoveFromSession(GetSessionKey(UserSessionKey));
            IRERPApplicationUtilities.RemoveFromClient(userid);
            if (HttpContext.Current.Items.Contains(logggeduser))
                HttpContext.Current.Items.Remove(logggeduser);
           // _loggeduser = null;
        }
        public static User LoggedUser
        {
            get
            {
                User _loggeduser = null;
                if(HttpContext.Current.Items.Contains(logggeduser))
                    _loggeduser =(User)HttpContext.Current.Items[logggeduser];

                else
                    HttpContext.Current.Items.Add(logggeduser, null);
                
                if (_loggeduser != null)
                    return _loggeduser;
                if (
                    IRERPApplicationUtilities.GetFromSession(GetSessionKey(UserSessionKey))
                    != null)
                {
                    Guid UserId = Guid.Empty;

                    Guid.TryParse(
                        IRERPApplicationUtilities.GetFromSession(GetSessionKey(UserSessionKey)).ToString(),
                        out UserId
                        );
                    _loggeduser = ModelRepositories.UserRepository.GetUserById(UserId);


                    HttpContext.Current.Items[logggeduser] = _loggeduser;
                    return _loggeduser;

                }
                else

                    if (IRERPApplicationUtilities.GetFromClient(userid) != null)
                    {
                        Guid
                            UserId = Guid.Empty;

                        Guid.TryParse(
                            IRERPApplicationUtilities.GetFromClient(userid).ToString(),
                            out UserId
                            );
                        try
                        {
                            _loggeduser = ModelRepositories.UserRepository.GetUserById(UserId);
                            if (_loggeduser != null)
                                IRERPApplicationUtilities.SaveToSession(GetSessionKey(UserSessionKey), _loggeduser.id);
                        }
                        catch
                        {
                        }
                        if(_loggeduser!=null)
                            HttpContext.Current.Items[logggeduser] = _loggeduser;
                        return _loggeduser;
                    }
#if DEBUG
                if (_loggeduser == null)
                {
                    _loggeduser = ModelRepositories.UserRepository.GetUserById(Guid.Empty);
                    return _loggeduser;
                }


#endif
                return null;
            }
            set
            {
                if (value != null)
                {
                    IRERPApplicationUtilities.SaveToSession(GetSessionKey(UserSessionKey), value.id);
                    IRERPApplicationUtilities.SaveToClient(userid, value.id.ToString());
                   // _loggeduser = value;
                    HttpContext.Current.Items[logggeduser] = value;

                }
                else
                {
                    logout();
                    if (HttpContext.Current.Items.Contains(logggeduser))
                        HttpContext.Current.Items.Remove(logggeduser);
                    //_loggeduser = value;
                }


            }
       }
       public static string  GetHelpByKey(string Key)
        {
          return   IRERP_RestAPI.ModelRepositories.Bases.Help_Repository.GetHelpByKey(Key.Trim()).HelpText;
        }

    }
}