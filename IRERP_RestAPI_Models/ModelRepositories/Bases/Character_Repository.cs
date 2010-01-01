using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.DataVirtualization;
using IRERP_RestAPI.Filters.Bases;
using MsdLib.CSharp.DataVirtualization;
namespace IRERP_RestAPI.ModelRepositories.Bases
{
    public class Character_Repository : IRERPRepositoryBaseSimpleFilter<Character_Repository, Character, CharacterFilter>
    {
        #region Generated
        public static Character ByPK(Guid PK)
                                {
                                    var filter = new CharacterFilter();
                                    filter.AddSimpleCriteria(x=>x.id,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
                                    filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

                                    return First(filter);
                                }  
                                                public static IList<Character> ListByAddedByPK<TParent>(Guid PK)
                                                    where TParent : MsdLib.CSharp.DALCore.ModelBase
                                                {
                                                    var filter = new CharacterFilter();
                                                    filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

                                                    filter.AddSimpleCriteria(x=>x.AddBy,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
                                                    return GetVList<TParent>(filter);
                                                }  
                                                public static IList<Character> ListByModifyByPK<TParent>(Guid PK)
                                                    where TParent : MsdLib.CSharp.DALCore.ModelBase
                                                {
                                                    var filter = new CharacterFilter();
                                                    filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

                                                    filter.AddSimpleCriteria(x=>x.ModifiedID,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
                                                    return GetVList<TParent>(filter);
                                                }
                                                    public static IList<Character> FilmActors()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"بازیگر فیلم");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> FilmClients()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"مشتری فیلم");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> FilmWriters()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"نویسنده فیلم");
                                               
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> FilmDirector()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"کارگردان فیلم");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> FilmSenarists()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"سناریونویس فیلم");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> FilmSpeakers()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"گوینده فیلم");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> FilmExecutives()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"مجری فیلم");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> FilmTechnicalExperts()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"تکنسین فنی فیلم");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> pictureclients()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"مشتری عکس");
                                               
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> Photographers()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"عکاس");
                                               
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> TechnicalExpert()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"تکنسین فنی");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> Speakers()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"گوینده");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> Actors()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"بازیگر");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> Writers()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"نویسنده");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> Directors()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"کارگردان");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> producres()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"تولید کننده");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> publishers()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"ناشر");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> TechnicalSupervisor()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"ناظر فنی");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> RadioPrints()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"چاپ رادیویی");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> typesettrs()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"تنظیم کننده تایپ");
                                               
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> BookBinder()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"صحاف");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> Client()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"مشتری");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> Senarists()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"سناریونویس");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> Printers()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"چاپگر");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> Editors()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"ویرایشگر");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> PageStylists()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"صفحه آرا");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> Graphists()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"گرافیست");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> Prepators()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"تهیه کننده");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> LitoGraphists()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"لیتوگرافیست");
                                               
                                                        return GetVList(filter);
                                                    }

        #endregion

        public static IRERPVList<Character, CharacterFilter> GetAllCharacter()
        {
            return GetVList(new CharacterFilter() { });
        }
        public static Character GetCharacterByID(System.Guid CharacterID)
        {
            var lst = GetVList(new CharacterFilter() { CharacterID = CharacterID });
            if (lst.Count > 0) return lst[0];
            return null;
        }
     

        public static IList<Character> GetAllCharacterByCharacterTypeID<TParent>(Guid CharacterTypeID)
    where TParent : MsdLib.CSharp.DALCore.ModelBase
        {
            return GetVList<TParent>(new CharacterFilter() { CharacterTypeID = CharacterTypeID });


        }


        public static IList<Character> GetCharacterByNatinalId<TParent>(Guid NatinalId)
 where TParent : MsdLib.CSharp.DALCore.ModelBase
        {
            return GetVList<TParent>(new CharacterFilter() { NatinalId = NatinalId });


        }


        public static bool Valid_Email(Character self)
        {
            var filter = new CharacterFilter() { EmailID = self.Email };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;

        }
        
        public static IList<Character> GetAllRanzerMan()
        {
            var filter = new CharacterFilter();
            filter.AddSimpleCriteria(x => x.RolsOfCharacter[0].CharacterRole.RoleName, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, "ÑÇäŽå ˜ÇÑ");
            filter.AddSimpleCriteria(x => x.RolsOfCharacter[0].CharacterRole.IsDeleted, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());
            filter.AddSimpleCriteria(x => x.RolsOfCharacter[0].IsDeleted, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());
            filter.AddSimpleCriteria(x => x.IsDeleted, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

            return GetVList(filter);
        }
        
    }
}
