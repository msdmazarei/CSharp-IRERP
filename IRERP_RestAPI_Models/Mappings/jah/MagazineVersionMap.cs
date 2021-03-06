
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
public class MagazineVersionMap : IRERPDescriptor<MagazineVersion> 
                            { public MagazineVersionMap(){Table(MsdTableName(null,"jah","MagazineVersion"));
LazyLoad();
Id(x=>x.id).Column("id");;
Version(x=>x.Version).Column("Version");
Map(x=>x.IsDeleted).Column("IsDeleted");
Map(x=>x.AddDate).Column("AddDate");
Map(x=>x.LastModifyDate).Column("LastModifyDate");
References<User>(x => x._____AddedBy).LazyLoad().Cascade.None().Column("AddedBy").NotFound.Ignore();
References<User>(x => x._____ModifyBy).LazyLoad().Cascade.None().Column("ModifyBy").NotFound.Ignore();
Map(x=>x.Description).Column("Description");
Map(x=>x.shomare).Column("shomare");
Map(x=>x.tirajh).Column("tirajh");
References<Magazine>(x => x._____Magazine).LazyLoad().Cascade.None().Column("Magazine").NotFound.Ignore();
References<Year>(x => x._____year).LazyLoad().Cascade.None().Column("year").NotFound.Ignore();
HasMany<MagazineVersion_mokhatab>(x => x._____mokhatab).LazyLoad().Cascade.None().KeyColumn("MagazineVersion").NotFound.Ignore();
HasMany<MagazineVersion_Ghate>(x => x._____Ghate).LazyLoad().Cascade.None().KeyColumn("MagazineVersion").NotFound.Ignore();
HasMany<MagazineVersion_modirmasoul>(x => x._____modirmasoul).LazyLoad().Cascade.None().KeyColumn("MagazineVersion").NotFound.Ignore();
HasMany<MagazineVersion_nevisandeh>(x => x._____nevisandeh).LazyLoad().Cascade.None().KeyColumn("MagazineVersion").NotFound.Ignore();
#region Any
DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(Hidden:true, PrimaryKey:true,Require:false,rootValue:null,title:"",valueMap:null);
#endregion

#region General
DescribeMember(x => x.shomare, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"شماره",valueMap:null);
DescribeMember(x => x.tirajh, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"تیراژ",valueMap:null);
DescribeMember(x => x.year, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.mokhatab, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Ghate, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.modirmasoul, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.nevisandeh, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
#endregion

}
}
public class MagazineVersionLogMap : IRERPDescriptor<MagazineVersionLog>
                                    {
 public MagazineVersionLogMap(){
Table(MsdTableName(null,"jah","MagazineVersionLog"));
LazyLoad();
Map(x=>x.id).Column("id");
Map(x=>x.Version).Column("Version");
Map(x=>x.IsDeleted).Column("IsDeleted");
Map(x=>x.AddDate).Column("AddDate");
Map(x=>x.LastModifyDate).Column("LastModifyDate");
References<User>(x => x._____AddedBy).LazyLoad().Cascade.None().Column("AddedBy").NotFound.Ignore();
References<User>(x => x._____ModifyBy).LazyLoad().Cascade.None().Column("ModifyBy").NotFound.Ignore();
Map(x=>x.Description).Column("Description");
Map(x=>x.shomare).Column("shomare");
Map(x=>x.tirajh).Column("tirajh");
References<Magazine>(x => x._____Magazine).LazyLoad().Cascade.None().Column("Magazine").NotFound.Ignore();
References<Year>(x => x._____year).LazyLoad().Cascade.None().Column("year").NotFound.Ignore();
Id(x => x.LogId).GeneratedBy.Guid().Column("Logid");
}
}
}

