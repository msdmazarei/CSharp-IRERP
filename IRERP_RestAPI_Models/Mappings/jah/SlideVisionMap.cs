
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
using IRERP_RestAPI.Models.Bases;
using IRERP_RestAPI.Models.jah;
using IRERP_RestAPI.Models.Bases;
namespace IRERP_RestAPI.Mappings.jah{
public class SlideVisionMap : IRERPDescriptor<SlideVision> 
                            { public SlideVisionMap(){Table(MsdTableName(null,"jah","SlideVision"));
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
Map(x=>x.SlideVisionTime);
Map(x=>x.ProductionDate);
Map(x=>x.Montage);
Map(x=>x.SlideVisionCode);
References<FilmProductionFormat>(x => x._____ProductionFormat).LazyLoad().Cascade.None().Column("ProductionFormat").NotFound.Ignore();
References<Character>(x => x._____Client).LazyLoad().Cascade.None().Column("Client").NotFound.Ignore();
HasMany<SlideVision_EducationalGoals>(x => x._____EducationalGoals).LazyLoad().Cascade.None().KeyColumn("SlideVision").NotFound.Ignore();
HasMany<SlideVision_TechnicalExperts>(x => x._____TechnicalExperts).LazyLoad().Cascade.None().KeyColumn("SlideVision").NotFound.Ignore();
HasMany<SlideVision_Speakers>(x => x._____Speakers).LazyLoad().Cascade.None().KeyColumn("SlideVision").NotFound.Ignore();
HasMany<SlideVision_Senarists>(x => x._____Senarists).LazyLoad().Cascade.None().KeyColumn("SlideVision").NotFound.Ignore();
HasMany<SlideVision_PhotoGraphists>(x => x._____PhotoGraphists).LazyLoad().Cascade.None().KeyColumn("SlideVision").NotFound.Ignore();
HasMany<SlideVision_Directors>(x => x._____Directors).LazyLoad().Cascade.None().KeyColumn("SlideVision").NotFound.Ignore();
HasMany<SlideVision_Audiences>(x => x._____Audiences).LazyLoad().Cascade.None().KeyColumn("SlideVision").NotFound.Ignore();
Map(x=>x.ProductedIn).Column("ProductedIn");
#region Any
DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(Hidden:true, PrimaryKey:true,Require:false,rootValue:null,title:"",valueMap:null);
DescribeMember(x => x.Version, IRERPProfile.Any).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"",valueMap:null);
#endregion

#region General
DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"توضیحات",valueMap:null);
DescribeMember(x => x.Title, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.SlideVisionTime, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"زمان",valueMap:null);
DescribeMember(x => x.ProductionDate, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"تاریخ تولید",valueMap:null);
DescribeMember(x => x.Montage, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"مونتاژ",valueMap:null);
DescribeMember(x => x.SlideVisionCode, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"کد",valueMap:null);
DescribeMember(x => x.ProductionFormat, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Client, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.EducationalGoals, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.TechnicalExperts, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Speakers, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Senarists, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.PhotoGraphists, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Directors, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Audiences, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.ProductedIn, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"تهیه شده در",valueMap:null);
#endregion

}
}
public class SlideVisionLogMap : IRERPDescriptor<SlideVisionLog>
                                    {
 public SlideVisionLogMap(){
Table(MsdTableName(null,"jah","SlideVisionLog"));
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
Map(x=>x.SlideVisionTime);
Map(x=>x.ProductionDate);
Map(x=>x.Montage);
Map(x=>x.SlideVisionCode);
References<FilmProductionFormat>(x => x._____ProductionFormat).LazyLoad().Cascade.None().Column("ProductionFormat").NotFound.Ignore();
References<Character>(x => x._____Client).LazyLoad().Cascade.None().Column("Client").NotFound.Ignore();
Map(x=>x.ProductedIn).Column("ProductedIn");
Id(x => x.LogId).GeneratedBy.Guid().Column("Logid");
}
}
}

