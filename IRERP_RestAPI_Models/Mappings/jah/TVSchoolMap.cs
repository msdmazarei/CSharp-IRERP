
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
public class TVSchoolMap : IRERPDescriptor<TVSchool> 
                            { public TVSchoolMap(){Table(MsdTableName(null,"jah","TVSchool"));
LazyLoad();
Id(x=>x.id).Column("id");;
Version(x=>x.Version).Column("Version");
Map(x=>x.IsDeleted).Column("IsDeleted");
Map(x=>x.AddDate).Column("AddDate");
Map(x=>x.LastModifyDate).Column("LastModifyDate");
References<User>(x => x._____AddedBy).LazyLoad().Cascade.None().Column("AddedBy").NotFound.Ignore();
References<User>(x => x._____ModifyBy).LazyLoad().Cascade.None().Column("ModifyBy").NotFound.Ignore();
Map(x=>x.Description).Column("Description");
Map(x=>x.TVSchoolName).Column("TVSchoolName");
Map(x=>x.TVTitle).Column("TVTitle");
Map(x=>x.PublicationNo).Column("PublicationNo");
Map(x=>x.PublicationCode).Column("PublicationCode");
HasMany<TVSchool_Publishers>(x => x._____Publishers).LazyLoad().Cascade.None().KeyColumn("TVSchool").NotFound.Ignore();
HasMany<TVSchool_Writers>(x => x._____Writers).LazyLoad().Cascade.None().KeyColumn("TVSchool").NotFound.Ignore();
HasMany<TVSchool_TechnicalExperts>(x => x._____TechnicalExperts).LazyLoad().Cascade.None().KeyColumn("TVSchool").NotFound.Ignore();
HasMany<TVSchool_TechnicalSupervisors>(x => x._____TechnicalSupervisors).LazyLoad().Cascade.None().KeyColumn("TVSchool").NotFound.Ignore();
HasMany<TVSchool_TVPrints>(x => x._____TVPrints).LazyLoad().Cascade.None().KeyColumn("TVSchool").NotFound.Ignore();
HasMany<TVSchool_TypeSetters>(x => x._____TypeSetters).LazyLoad().Cascade.None().KeyColumn("TVSchool").NotFound.Ignore();
HasMany<TVSchool_Editors>(x => x._____Editors).LazyLoad().Cascade.None().KeyColumn("TVSchool").NotFound.Ignore();
HasMany<TVSchool_PageStylists>(x => x._____PageStylists).LazyLoad().Cascade.None().KeyColumn("TVSchool").NotFound.Ignore();
HasMany<TVSchool_Graphists>(x => x._____Graphists).LazyLoad().Cascade.None().KeyColumn("TVSchool").NotFound.Ignore();
HasMany<TVSchool_Preparators>(x => x._____Preparators).LazyLoad().Cascade.None().KeyColumn("TVSchool").NotFound.Ignore();
Map(x=>x.PublicationDate).Column("PublicationDate");
Map(x=>x.DistributionDate).Column("DistributionDate");
Map(x=>x.Tirajh).Column("Tirajh");
HasMany<TVSchool_LitoGraphists>(x => x._____LitoGraphists).LazyLoad().Cascade.None().KeyColumn("TVSchool").NotFound.Ignore();
Map(x=>x.Address).Column("Address");
Map(x=>x.Tel).Column("Tel");
Map(x=>x.Fax).Column("Fax");
Map(x=>x.PublicationPeriod).Column("PublicationPeriod");
HasMany<TVSchool_BookBinders>(x => x._____BookBinders).LazyLoad().Cascade.None().KeyColumn("TVSchool").NotFound.Ignore();
Map(x=>x.CenterName).Column("CenterName");
HasMany<TVSchool_Audiences>(x => x._____Audiences).LazyLoad().Cascade.None().KeyColumn("TVSchool").NotFound.Ignore();
HasMany<TVSchool_EducationalGoals>(x => x._____EducationalGoals).LazyLoad().Cascade.None().KeyColumn("TVSchool").NotFound.Ignore();
#region Any
DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(Hidden:true, PrimaryKey:true,Require:false,rootValue:null,title:"",valueMap:null);
DescribeMember(x => x.Version, IRERPProfile.Any).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"",valueMap:null);
#endregion

#region General
DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"",valueMap:null);
DescribeMember(x => x.TVSchoolName, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"نام",valueMap:null);
DescribeMember(x => x.TVTitle, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"عنوان",valueMap:null);
DescribeMember(x => x.PublicationNo, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"شماره نشریه",valueMap:null);
DescribeMember(x => x.PublicationCode, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"کد نشریه",valueMap:null);
DescribeMember(x => x.Publishers, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Writers, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.TechnicalExperts, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.TechnicalSupervisors, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.TVPrints, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.TypeSetters, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Editors, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.PageStylists, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Graphists, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Preparators, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.PublicationDate, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"تاریخ انتشار",valueMap:null);
DescribeMember(x => x.DistributionDate, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"تاریخ پخش",valueMap:null);
DescribeMember(x => x.Tirajh, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"تیراژ",valueMap:null);
DescribeMember(x => x.LitoGraphists, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Address, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"آدرس",valueMap:null);
DescribeMember(x => x.Tel, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"تلفن",valueMap:null);
DescribeMember(x => x.Fax, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"فاکس",valueMap:null);
DescribeMember(x => x.PublicationPeriod, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"نوبت چاپ",valueMap:null);
DescribeMember(x => x.BookBinders, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.CenterName, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"مرکز",valueMap:null);
DescribeMember(x => x.Audiences, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.EducationalGoals, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
#endregion

}
}
public class TVSchoolLogMap : IRERPDescriptor<TVSchoolLog>
                                    {
 public TVSchoolLogMap(){
Table(MsdTableName(null,"jah","TVSchoolLog"));
LazyLoad();
Map(x=>x.id).Column("id");
Map(x=>x.Version).Column("Version");
Map(x=>x.IsDeleted).Column("IsDeleted");
Map(x=>x.AddDate).Column("AddDate");
Map(x=>x.LastModifyDate).Column("LastModifyDate");
References<User>(x => x._____AddedBy).LazyLoad().Cascade.None().Column("AddedBy").NotFound.Ignore();
References<User>(x => x._____ModifyBy).LazyLoad().Cascade.None().Column("ModifyBy").NotFound.Ignore();
Map(x=>x.Description).Column("Description");
Map(x=>x.TVSchoolName).Column("TVSchoolName");
Map(x=>x.TVTitle).Column("TVTitle");
Map(x=>x.PublicationNo).Column("PublicationNo");
Map(x=>x.PublicationCode).Column("PublicationCode");
Map(x=>x.PublicationDate).Column("PublicationDate");
Map(x=>x.DistributionDate).Column("DistributionDate");
Map(x=>x.Tirajh).Column("Tirajh");
Map(x=>x.Address).Column("Address");
Map(x=>x.Tel).Column("Tel");
Map(x=>x.Fax).Column("Fax");
Map(x=>x.PublicationPeriod).Column("PublicationPeriod");
Map(x=>x.CenterName).Column("CenterName");
Id(x => x.LogId).GeneratedBy.Guid().Column("Logid");
}
}
}

