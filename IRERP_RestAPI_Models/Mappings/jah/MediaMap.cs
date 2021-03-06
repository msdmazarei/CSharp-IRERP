
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
public class MediaMap : IRERPDescriptor<Media> 
                            { public MediaMap(){Table(MsdTableName(null,"jah","Media"));
LazyLoad();
Id(x=>x.id).Column("id");;
Version(x=>x.Version).Column("Version");
Map(x=>x.IsDeleted).Column("IsDeleted");
Map(x=>x.AddDate).Column("AddDate");
Map(x=>x.LastModifyDate).Column("LastModifyDate");
References<User>(x => x._____AddedBy).LazyLoad().Cascade.None().Column("AddedBy").NotFound.Ignore();
References<User>(x => x._____ModifyBy).LazyLoad().Cascade.None().Column("ModifyBy").NotFound.Ignore();
Map(x=>x.Description).Column("Description");
Map(x=>x.tedad_barnameh).Column("tedad_barnameh");
Map(x=>x.shomareh).Column("shomareh");
References<Title>(x => x._____onvan).LazyLoad().Cascade.None().Column("onvan").NotFound.Ignore();
References<TVRD>(x => x._____tv_rd).LazyLoad().Cascade.None().Column("tv_rd").NotFound.Ignore();
HasMany<Media_mozuaat>(x => x._____mozuaat).LazyLoad().Cascade.None().KeyColumn("Media").NotFound.Ignore();
HasMany<Media_sathe_mokhatab>(x => x._____sathe_mokhatab).LazyLoad().Cascade.None().KeyColumn("Media").NotFound.Ignore();
HasMany<Media_ostan>(x => x._____ostan).LazyLoad().Cascade.None().KeyColumn("Media").NotFound.Ignore();
HasMany<Section>(x => x._____bakhshha).LazyLoad().Cascade.None().KeyColumn("Media").NotFound.Ignore();
#region Any
DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(Hidden:true, PrimaryKey:true,Require:false,rootValue:null,title:"",valueMap:null);
#endregion

#region General
DescribeMember(x => x.tedad_barnameh, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"تعداد برنامه",valueMap:null);
DescribeMember(x => x.shomareh, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"شماره",valueMap:null);
DescribeMember(x => x.onvan, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.tv_rd, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.mozuaat, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.sathe_mokhatab, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.ostan, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.bakhshha, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
#endregion

}
}
public class MediaLogMap : IRERPDescriptor<MediaLog>
                                    {
 public MediaLogMap(){
Table(MsdTableName(null,"jah","MediaLog"));
LazyLoad();
Map(x=>x.id).Column("id");
Map(x=>x.Version).Column("Version");
Map(x=>x.IsDeleted).Column("IsDeleted");
Map(x=>x.AddDate).Column("AddDate");
Map(x=>x.LastModifyDate).Column("LastModifyDate");
References<User>(x => x._____AddedBy).LazyLoad().Cascade.None().Column("AddedBy").NotFound.Ignore();
References<User>(x => x._____ModifyBy).LazyLoad().Cascade.None().Column("ModifyBy").NotFound.Ignore();
Map(x=>x.Description).Column("Description");
Map(x=>x.tedad_barnameh).Column("tedad_barnameh");
Map(x=>x.shomareh).Column("shomareh");
References<Title>(x => x._____onvan).LazyLoad().Cascade.None().Column("onvan").NotFound.Ignore();
References<TVRD>(x => x._____tv_rd).LazyLoad().Cascade.None().Column("tv_rd").NotFound.Ignore();
Id(x => x.LogId).GeneratedBy.Guid().Column("Logid");
}
}
}

