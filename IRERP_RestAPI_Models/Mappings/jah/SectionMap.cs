
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
public class SectionMap : IRERPDescriptor<Section> 
                            { public SectionMap(){Table(MsdTableName(null,"jah","section"));
LazyLoad();
Id(x=>x.id).Column("id");;
Version(x=>x.Version).Column("Version");
Map(x=>x.IsDeleted).Column("IsDeleted");
Map(x=>x.AddDate).Column("AddDate");
Map(x=>x.LastModifyDate).Column("LastModifyDate");
References<User>(x => x._____AddedBy).LazyLoad().Cascade.None().Column("AddedBy").NotFound.Ignore();
References<User>(x => x._____ModifyBy).LazyLoad().Cascade.None().Column("ModifyBy").NotFound.Ignore();
Map(x=>x.Description).Column("Description");
References<Media>(x => x._____Media).LazyLoad().Cascade.None().Column("Media").NotFound.Ignore();
Map(x=>x.nobat);
Map(x=>x.Pakhsh);
Map(x=>x.enteshar);
HasMany<Section_karshenas>(x => x._____karshenas).LazyLoad().Cascade.None().KeyColumn("Section").NotFound.Ignore();
Map(x=>x.tirajh).Column("tirajh");
HasMany<Section_sardabir>(x => x._____sardabir).LazyLoad().Cascade.None().KeyColumn("Section").NotFound.Ignore();
#region Any
DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(Hidden:true, PrimaryKey:true,Require:false,rootValue:null,title:"",valueMap:null);
#endregion

#region General
DescribeMember(x => x.nobat, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"نوبت",valueMap:null);
DescribeMember(x => x.Pakhsh, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"پخش",valueMap:null);
DescribeMember(x => x.enteshar, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"انتشار",valueMap:null);
DescribeMember(x => x.karshenas, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.tirajh, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"تیراژ",valueMap:null);
DescribeMember(x => x.sardabir, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
#endregion

}
}
public class SectionLogMap : IRERPDescriptor<SectionLog>
                                    {
 public SectionLogMap(){
Table(MsdTableName(null,"jah","sectionLog"));
LazyLoad();
Map(x=>x.id).Column("id");
Map(x=>x.Version).Column("Version");
Map(x=>x.IsDeleted).Column("IsDeleted");
Map(x=>x.AddDate).Column("AddDate");
Map(x=>x.LastModifyDate).Column("LastModifyDate");
References<User>(x => x._____AddedBy).LazyLoad().Cascade.None().Column("AddedBy").NotFound.Ignore();
References<User>(x => x._____ModifyBy).LazyLoad().Cascade.None().Column("ModifyBy").NotFound.Ignore();
Map(x=>x.Description).Column("Description");
References<Media>(x => x._____Media).LazyLoad().Cascade.None().Column("Media").NotFound.Ignore();
Map(x=>x.nobat);
Map(x=>x.Pakhsh);
Map(x=>x.enteshar);
Map(x=>x.tirajh).Column("tirajh");
Id(x => x.LogId).GeneratedBy.Guid().Column("Logid");
}
}
}

