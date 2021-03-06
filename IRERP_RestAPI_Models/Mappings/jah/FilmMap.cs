
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
public class FilmMap : IRERPDescriptor<Film> 
                            { public FilmMap(){Table(MsdTableName(null,"jah","Film"));
LazyLoad();
Id(x=>x.id).Column("id");;
Version(x=>x.Version).Column("Version");
Map(x=>x.IsDeleted).Column("IsDeleted");
Map(x=>x.AddDate).Column("AddDate");
Map(x=>x.LastModifyDate).Column("LastModifyDate");
References<User>(x => x._____AddedBy).LazyLoad().Cascade.None().Column("AddedBy").NotFound.Ignore();
References<User>(x => x._____ModifyBy).LazyLoad().Cascade.None().Column("ModifyBy").NotFound.Ignore();
Map(x=>x.Description).Column("Description");
Map(x=>x.FilmName).Column("FilmName");
Map(x=>x.FilmTime);
Map(x=>x.ProductionDate);
Map(x=>x.PersianProductionDate);
Map(x=>x.Montage);
Map(x=>x.FilmCode);
Map(x=>x.FilmabstracFile);
References<FilmProductionFormat>(x => x._____ProductionFormat).LazyLoad().Cascade.None().Column("ProductionFormat").NotFound.Ignore();
References<Character>(x => x._____Client).LazyLoad().Cascade.None().Column("Client").NotFound.Ignore();
References<FilmSystemType>(x => x._____SystemType).LazyLoad().Cascade.None().Column("SystemType").NotFound.Ignore();
HasMany<Film_Executives>(x => x._____Executives).LazyLoad().Cascade.None().KeyColumn("Film").NotFound.Ignore();
HasMany<FilmContentlist>(x => x._____FilmContentlists).LazyLoad().Cascade.None().KeyColumn("Film").NotFound.Ignore();
HasMany<Film_EducationalGoals>(x => x._____EducationalGoals).LazyLoad().Cascade.None().KeyColumn("Film").NotFound.Ignore();
HasMany<Film_TechnicalExperts>(x => x._____TechnicalExperts).LazyLoad().Cascade.None().KeyColumn("Film").NotFound.Ignore();
HasMany<Film_Speakers>(x => x._____Speakers).LazyLoad().Cascade.None().KeyColumn("Film").NotFound.Ignore();
HasMany<Film_Senarists>(x => x._____Senarists).LazyLoad().Cascade.None().KeyColumn("Film").NotFound.Ignore();
HasMany<Film_Actors>(x => x._____Actors).LazyLoad().Cascade.None().KeyColumn("Film").NotFound.Ignore();
HasMany<Film_Writers>(x => x._____Writers).LazyLoad().Cascade.None().KeyColumn("Film").NotFound.Ignore();
HasMany<Film_Directors>(x => x._____Directors).LazyLoad().Cascade.None().KeyColumn("Film").NotFound.Ignore();
#region Any
DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(Hidden:true, PrimaryKey:true,Require:false,rootValue:null,title:"",valueMap:null);
DescribeMember(x => x.FilmCode, IRERPProfile.Any).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"کد فیلم",valueMap:null);
#endregion

#region General
DescribeMember(x => x.FilmName, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"نام فیلم",valueMap:null);
DescribeMember(x => x.FilmTime, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"مدت فیلم",valueMap:null);
DescribeMember(x => x.PersianProductionDate, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"تاریخ تولید",valueMap:null);
DescribeMember(x => x.Montage, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"مونتاژ",valueMap:null);
DescribeMember(x => x.FilmabstracFile, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"خلاصه فیلم",valueMap:null);
DescribeMember(x => x.ProductionFormat, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Client, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.SystemType, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Executives, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.FilmContentlists, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.EducationalGoals, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.TechnicalExperts, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Speakers, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Senarists, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Actors, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Writers, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Directors, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
#endregion

#region Abstract
DescribeMember(x => x.FilmName, IRERPProfile.Abstract).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"نام فیلم",valueMap:null);
DescribeMember(x => x.ProductionFormat, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.Client, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.SystemType, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
#endregion

#region Detail
DescribeMember(x => x.FilmName, IRERPProfile.Detail).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"نام فیلم",valueMap:null);
DescribeMember(x => x.ProductionFormat, IRERPProfile.Detail).UserAsProfile(IRERPProfile.Detail);
DescribeMember(x => x.Client, IRERPProfile.Detail).UserAsProfile(IRERPProfile.Detail);
DescribeMember(x => x.SystemType, IRERPProfile.Detail).UserAsProfile(IRERPProfile.Detail);
#endregion

}
}
}

