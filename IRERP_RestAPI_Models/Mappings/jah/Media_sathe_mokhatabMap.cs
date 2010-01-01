
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
public class Media_sathe_mokhatabMap : IRERPDescriptor<Media_sathe_mokhatab> 
                            { public Media_sathe_mokhatabMap(){Table(MsdTableName(null,"jah","Media_sathe_mokhatab"));
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
References<Auidunce>(x => x._____Auidunce).LazyLoad().Cascade.None().Column("Auidunce").NotFound.Ignore();
#region Any
DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(Hidden:true, PrimaryKey:true,Require:false,rootValue:null,title:"",valueMap:null);
#endregion

#region General
DescribeMember(x => x.Auidunce, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
#endregion

}
}
}

