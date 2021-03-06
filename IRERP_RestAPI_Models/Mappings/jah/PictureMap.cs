
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
using IRERP_RestAPI.Models.Bases;
using IRERP_RestAPI.Models.jah;
namespace IRERP_RestAPI.Mappings.jah{
public class PictureMap : IRERPDescriptor<Picture> 
                            { public PictureMap(){Table(MsdTableName(null,"jah","picture"));
LazyLoad();
Id(x=>x.id).Column("id");;
Version(x=>x.Version).Column("Version");
Map(x=>x.IsDeleted).Column("IsDeleted");
Map(x=>x.AddDate).Column("AddDate");
Map(x=>x.LastModifyDate).Column("LastModifyDate");
References<User>(x => x._____AddedBy).LazyLoad().Cascade.None().Column("AddedBy").NotFound.Ignore();
References<User>(x => x._____ModifyBy).LazyLoad().Cascade.None().Column("ModifyBy").NotFound.Ignore();
Map(x=>x.Description).Column("Description");
Map(x=>x.piccode);
Map(x=>x.shotdate);
References<Character>(x => x._____client).LazyLoad().Cascade.None().Column("client").NotFound.Ignore();
References<Title>(x => x._____title).LazyLoad().Cascade.None().Column("title").NotFound.Ignore();
References<Size>(x => x._____Size).LazyLoad().Cascade.None().Column("Size").NotFound.Ignore();
References<Resulation>(x => x._____resulation).LazyLoad().Cascade.None().Column("resulation").NotFound.Ignore();
Map(x=>x.Location);
References<Character>(x => x._____Photographer).LazyLoad().Cascade.None().Column("Photographer").NotFound.Ignore();
References<PictureType>(x => x._____pictype).LazyLoad().Cascade.None().Column("pictype").NotFound.Ignore();
References<PictureFormat>(x => x._____picformat).LazyLoad().Cascade.None().Column("picformat").NotFound.Ignore();
#region Any
DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(Hidden:true, PrimaryKey:true,Require:false,rootValue:null,title:"",valueMap:null);
#endregion

#region General
DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"توضیحات",valueMap:null);
DescribeMember(x => x.piccode, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"کد عکس",valueMap:null);
DescribeMember(x => x.shotdate, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"تاریخ عکس برداری",valueMap:null);
DescribeMember(x => x.client, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.title, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Size, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.resulation, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Location, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"مکان عکس برداری",valueMap:null);
DescribeMember(x => x.Photographer, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.pictype, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.picformat, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
#endregion

}
}
public class PictureLogMap : IRERPDescriptor<PictureLog>
                                    {
 public PictureLogMap(){
Table(MsdTableName(null,"jah","pictureLog"));
LazyLoad();
Map(x=>x.id).Column("id");
Map(x=>x.Version).Column("Version");
Map(x=>x.IsDeleted).Column("IsDeleted");
Map(x=>x.AddDate).Column("AddDate");
Map(x=>x.LastModifyDate).Column("LastModifyDate");
References<User>(x => x._____AddedBy).LazyLoad().Cascade.None().Column("AddedBy").NotFound.Ignore();
References<User>(x => x._____ModifyBy).LazyLoad().Cascade.None().Column("ModifyBy").NotFound.Ignore();
Map(x=>x.Description).Column("Description");
Map(x=>x.piccode);
Map(x=>x.shotdate);
References<Character>(x => x._____client).LazyLoad().Cascade.None().Column("client").NotFound.Ignore();
References<Title>(x => x._____title).LazyLoad().Cascade.None().Column("title").NotFound.Ignore();
References<Size>(x => x._____Size).LazyLoad().Cascade.None().Column("Size").NotFound.Ignore();
References<Resulation>(x => x._____resulation).LazyLoad().Cascade.None().Column("resulation").NotFound.Ignore();
Map(x=>x.Location);
References<Character>(x => x._____Photographer).LazyLoad().Cascade.None().Column("Photographer").NotFound.Ignore();
References<PictureType>(x => x._____pictype).LazyLoad().Cascade.None().Column("pictype").NotFound.Ignore();
References<PictureFormat>(x => x._____picformat).LazyLoad().Cascade.None().Column("picformat").NotFound.Ignore();
Id(x => x.LogId).GeneratedBy.Guid().Column("Logid");
}
}
}

