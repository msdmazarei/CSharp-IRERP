
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
public class PlayShowMap : IRERPDescriptor<PlayShow> 
                            { public PlayShowMap(){Table(MsdTableName(null,"jah","PlayShow"));
LazyLoad();
Id(x=>x.id).Column("id");;
Version(x=>x.Version).Column("Version");
Map(x=>x.IsDeleted).Column("IsDeleted");
Map(x=>x.AddDate).Column("AddDate");
Map(x=>x.LastModifyDate).Column("LastModifyDate");
References<User>(x => x._____AddedBy).LazyLoad().Cascade.None().Column("AddedBy").NotFound.Ignore();
References<User>(x => x._____ModifyBy).LazyLoad().Cascade.None().Column("ModifyBy").NotFound.Ignore();
Map(x=>x.Description).Column("Description");
References<Title>(x => x._____Title).LazyLoad().Cascade.None().Column("Title").NotFound.Ignore();
Map(x=>x.PlayShowTime);
Map(x=>x.Center);
Map(x=>x.PlayShowCode);
HasMany<PlayShow_EducationalGoals>(x => x._____EducationalGoals).LazyLoad().Cascade.None().KeyColumn("PlayShow").NotFound.Ignore();
HasMany<PlayShow_TechnicalExperts>(x => x._____TechnicalExperts).LazyLoad().Cascade.None().KeyColumn("PlayShow").NotFound.Ignore();
HasMany<PlayShow_Speakers>(x => x._____Speakers).LazyLoad().Cascade.None().KeyColumn("PlayShow").NotFound.Ignore();
HasMany<PlayShow_Actors>(x => x._____Actors).LazyLoad().Cascade.None().KeyColumn("PlayShow").NotFound.Ignore();
HasMany<PlayShow_Writers>(x => x._____Writers).LazyLoad().Cascade.None().KeyColumn("PlayShow").NotFound.Ignore();
HasMany<PlayShow_Directors>(x => x._____Directors).LazyLoad().Cascade.None().KeyColumn("PlayShow").NotFound.Ignore();
HasMany<PlayShow_Producers>(x => x._____Producers).LazyLoad().Cascade.None().KeyColumn("PlayShow").NotFound.Ignore();
HasMany<PlayShow_Audiences>(x => x._____Audiences).LazyLoad().Cascade.None().KeyColumn("PlayShow").NotFound.Ignore();
HasMany<PlayShowContentlist>(x => x._____PlayShowContentlists).LazyLoad().Cascade.None().KeyColumn("PlayShow").NotFound.Ignore();
#region Any
DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(Hidden:true, PrimaryKey:true,Require:false,rootValue:null,title:"",valueMap:null);
#endregion

#region General
DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"توضیحات",valueMap:null);
DescribeMember(x => x.Title, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.PlayShowTime, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"مدت زمان",valueMap:null);
DescribeMember(x => x.Center, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"مرکز",valueMap:null);
DescribeMember(x => x.PlayShowCode, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"کد",valueMap:null);
DescribeMember(x => x.EducationalGoals, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.TechnicalExperts, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Speakers, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Actors, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Writers, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Directors, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Producers, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Audiences, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
#endregion

}
}
public class PlayShowLogMap : IRERPDescriptor<PlayShowLog>
                                    {
 public PlayShowLogMap(){
Table(MsdTableName(null,"jah","PlayShowLog"));
LazyLoad();
Map(x=>x.id).Column("id");
Map(x=>x.Version).Column("Version");
Map(x=>x.IsDeleted).Column("IsDeleted");
Map(x=>x.AddDate).Column("AddDate");
Map(x=>x.LastModifyDate).Column("LastModifyDate");
References<User>(x => x._____AddedBy).LazyLoad().Cascade.None().Column("AddedBy").NotFound.Ignore();
References<User>(x => x._____ModifyBy).LazyLoad().Cascade.None().Column("ModifyBy").NotFound.Ignore();
Map(x=>x.Description).Column("Description");
References<Title>(x => x._____Title).LazyLoad().Cascade.None().Column("Title").NotFound.Ignore();
Map(x=>x.PlayShowTime);
Map(x=>x.Center);
Map(x=>x.PlayShowCode);
Id(x => x.LogId).GeneratedBy.Guid().Column("Logid");
}
}
}

