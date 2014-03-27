using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using MsdLib.ExtentionFuncs.Strings;

namespace IRERP_RestAPI.Mappings.Bases
{
    public class CallInfoMap : IRERPDescriptor<CallInfo>
    {
        public CallInfoMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "CallInfo"));
            
            LazyLoad();
            Version(x => x.Version);
            Id(x => x.id).GeneratedBy.Guid().Column("id");
            Map(x => x.CallNumber).Column("CallNumber").Not.Nullable();
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");
            Map(x => x.Description).Column("Description");

            References<CallInfoType>(x => x._____CallInfoType).LazyLoad().Cascade.None().Column("Type");
            References<Character>(x => x._____Character).LazyLoad().Cascade.None().Column("CharacterID");


            #region Any
            DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true, Hidden: true);
            DescribeMember(x => x.Version, IRERPProfile.Any).DataSourceFieldProperty(Hidden: true);
            DescribeMember(x => x.PersianAddByDAte, IRERPProfile.Any)
           .AliasForProperty(_GPN(x => x.AddByDAte))
           .DataSourceFieldProperty(title: ApplicationStatics.T("ADDDate"));

            DescribeMember(x => x.PersianModifiyDate, IRERPProfile.Any)
            .AliasForProperty(_GPN(x => x.ModifiyDate))
            .DataSourceFieldProperty(title: ApplicationStatics.T("ModifayDate"));
            #endregion

         

            #region General
                            DescribeMember(x => x.CallNumber, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("CallInfoCallNumber"));
            DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("CallInfoDescription"));
            DescribeMember(x => x.CallInfoType, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.Characters, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            #endregion

            #region D_CallInfo
            DescribeMember(x => x.CallNumber, IRERPProfile.D_CallInfo).DataSourceFieldProperty(title: ApplicationStatics.T("CallInfoCallNumber"));
            DescribeMember(x => x.Description, IRERPProfile.D_CallInfo).DataSourceFieldProperty(title: ApplicationStatics.T("CallInfoDescription"));
            DescribeMember(x => x.CallInfoType, IRERPProfile.D_CallInfo).UserAsProfile(IRERPProfile.Abstract);
            #endregion




        }
    }
}
