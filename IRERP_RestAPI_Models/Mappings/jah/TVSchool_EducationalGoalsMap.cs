
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
public class TVSchool_EducationalGoalsMap : IRERPDescriptor<TVSchool_EducationalGoals> 
                            { public TVSchool_EducationalGoalsMap(){Table(MsdTableName(null,"jah","TVSchool_EducationalGoals"));
LazyLoad();
Id(x=>x.id).Column("id");;
Version(x=>x.Version).Column("Version");
Map(x=>x.IsDeleted).Column("IsDeleted");
Map(x=>x.AddDate).Column("AddDate");
Map(x=>x.LastModifyDate).Column("LastModifyDate");
References<User>(x => x._____AddedBy).LazyLoad().Cascade.None().Column("AddedBy").NotFound.Ignore();
References<User>(x => x._____ModifyBy).LazyLoad().Cascade.None().Column("ModifyBy").NotFound.Ignore();
Map(x=>x.Description).Column("Description");
References<TVSchool>(x => x._____TVSchool).LazyLoad().Cascade.None().Column("TVSchool").NotFound.Ignore();
References<FilmEducationalGoal>(x => x._____FilmEducationalGoal).LazyLoad().Cascade.None().Column("FilmEducationalGoal").NotFound.Ignore();
#region Any
DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(Hidden:true, PrimaryKey:true,Require:false,rootValue:null,title:"",valueMap:null);
DescribeMember(x => x.Version, IRERPProfile.Any).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"",valueMap:null);
#endregion

#region General
DescribeMember(x => x.FilmEducationalGoal, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
#endregion

}
}
}

