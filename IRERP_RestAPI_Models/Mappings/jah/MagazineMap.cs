
using IRERP_RestAPI.Bases;
using MsdLib.CSharp.DALCore;
using MsdLib.Types;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using MsdLib.ExtentionFuncs.Strings;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using IRERP_RestAPI.Models.jah;
using IRERP_RestAPI.Models;
using IRERP_RestAPI.Models.jah;
namespace IRERP_RestAPI.Mappings.jah{
public class MagazineMap : IRERPDescriptor<Magazine> 
                            { public MagazineMap(){Table(MsdTableName(null,"jah","Magazine"));
LazyLoad();
Id(x=>x.id).Column("id");;
Version(x=>x.Version).Column("Version");
Map(x=>x.IsDeleted).Column("IsDeleted");
Map(x=>x.AddDate).Column("AddDate");
Map(x=>x.LastModifyDate).Column("LastModifyDate");
References<User>(x => x._____AddedBy).LazyLoad().Cascade.None().Column("AddedBy").NotFound.Ignore();
References<User>(x => x._____ModifyBy).LazyLoad().Cascade.None().Column("ModifyBy").NotFound.Ignore();
Map(x=>x.Description).Column("Description");
References<Title>(x => x._____onvan).LazyLoad().Cascade.None().Column("onvan").NotFound.Ignore();
References<MagazineType>(x => x._____noe_majale).LazyLoad().Cascade.None().Column("noe_majale").NotFound.Ignore();
HasMany<Magazine_mozuaat>(x => x._____mozuaat).LazyLoad().Cascade.None().KeyColumn("Magazine").NotFound.Ignore();
HasMany<MagazineVersion>(x => x._____magver).LazyLoad().Cascade.None().KeyColumn("Magazine").NotFound.Ignore();
#region Any
DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(Hidden:true, PrimaryKey:true,Require:false,rootValue:null,title:"",valueMap:null);
DescribeMember(x => x.Version, IRERPProfile.Any).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"",valueMap:null);
#endregion

#region General
DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"توضیحات",valueMap:null);
DescribeMember(x => x.onvan, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.noe_majale, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.mozuaat, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.magver, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
#endregion

}
}
public class MagazineLogMap : IRERPDescriptor<MagazineLog>
                                    {
 public MagazineLogMap(){
Table(MsdTableName(null,"jah","MagazineLog"));
LazyLoad();
Map(x=>x.id).Column("id");
Map(x=>x.Version).Column("Version");
Map(x=>x.IsDeleted).Column("IsDeleted");
Map(x=>x.AddDate).Column("AddDate");
Map(x=>x.LastModifyDate).Column("LastModifyDate");
References<User>(x => x._____AddedBy).LazyLoad().Cascade.None().Column("AddedBy").NotFound.Ignore();
References<User>(x => x._____ModifyBy).LazyLoad().Cascade.None().Column("ModifyBy").NotFound.Ignore();
Map(x=>x.Description).Column("Description");
References<Title>(x => x._____onvan).LazyLoad().Cascade.None().Column("onvan").NotFound.Ignore();
References<MagazineType>(x => x._____noe_majale).LazyLoad().Cascade.None().Column("noe_majale").NotFound.Ignore();
Id(x => x.LogId).GeneratedBy.Guid().Column("Logid");
}
}
}

