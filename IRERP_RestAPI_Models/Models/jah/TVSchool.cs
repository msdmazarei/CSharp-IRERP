
using IRERP_RestAPI.Bases;
using MsdLib.CSharp.DALCore;
using MsdLib.Types;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using MsdLib.ExtentionFuncs.Strings;
using System.Linq;
using IRERP_RestAPI.Models.jah;
namespace IRERP_RestAPI.Models.jah{
public class TVSchool:IRERP_RestAPI.Bases.ModelBaseLog<TVSchool, TVSchoolLog>{
public virtual DateTime AddDate { get; set; }

public virtual DateTime LastModifyDate { get; set; }


                                            LoadableVar<User> _AddedBy= new LoadableVar<User>();
                                            public virtual User _____AddedBy { get; set; }
                                            public virtual User AddedBy
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<User, Guid>
                                                        (ref _AddedBy,
                                                        x => x._____AddedBy,
                                                        ModelRepositories.UserRepository.ByPK,
                                                        x => x._____AddedBy.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.AddedBy, x => x._____AddedBy, _AddedBy, value);

                                                }
                                            }
                                    

                                            LoadableVar<User> _ModifyBy= new LoadableVar<User>();
                                            public virtual User _____ModifyBy { get; set; }
                                            public virtual User ModifyBy
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<User, Guid>
                                                        (ref _ModifyBy,
                                                        x => x._____ModifyBy,
                                                        ModelRepositories.UserRepository.ByPK,
                                                        x => x._____ModifyBy.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.ModifyBy, x => x._____ModifyBy, _ModifyBy, value);

                                                }
                                            }
                                    
public virtual string Description { get; set; }

public virtual string TVSchoolName { get; set; }

public virtual string TVTitle { get; set; }

public virtual string PublicationNo { get; set; }

public virtual string PublicationCode { get; set; }


                                LoadableVar<IList<TVSchool_Publishers>> _Publishers = new LoadableVar<IList<TVSchool_Publishers>>();
                                public virtual IList<TVSchool_Publishers> _____Publishers { get; set; }
                                public virtual IList<TVSchool_Publishers> Publishers
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<TVSchool_Publishers, Guid>(ref _Publishers, x => x._____Publishers,
                                            ModelRepositories.jah.TVSchool_Publishers_Repository.ListByTVSchoolPK<TVSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.TVSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Publishers, x => x._____Publishers, _Publishers, value); }
                                }

                                    

                                LoadableVar<IList<TVSchool_Writers>> _Writers = new LoadableVar<IList<TVSchool_Writers>>();
                                public virtual IList<TVSchool_Writers> _____Writers { get; set; }
                                public virtual IList<TVSchool_Writers> Writers
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<TVSchool_Writers, Guid>(ref _Writers, x => x._____Writers,
                                            ModelRepositories.jah.TVSchool_Writers_Repository.ListByTVSchoolPK<TVSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.TVSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Writers, x => x._____Writers, _Writers, value); }
                                }

                                    

                                LoadableVar<IList<TVSchool_TechnicalExperts>> _TechnicalExperts = new LoadableVar<IList<TVSchool_TechnicalExperts>>();
                                public virtual IList<TVSchool_TechnicalExperts> _____TechnicalExperts { get; set; }
                                public virtual IList<TVSchool_TechnicalExperts> TechnicalExperts
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<TVSchool_TechnicalExperts, Guid>(ref _TechnicalExperts, x => x._____TechnicalExperts,
                                            ModelRepositories.jah.TVSchool_TechnicalExperts_Repository.ListByTVSchoolPK<TVSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.TVSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.TechnicalExperts, x => x._____TechnicalExperts, _TechnicalExperts, value); }
                                }

                                    

                                LoadableVar<IList<TVSchool_TechnicalSupervisors>> _TechnicalSupervisors = new LoadableVar<IList<TVSchool_TechnicalSupervisors>>();
                                public virtual IList<TVSchool_TechnicalSupervisors> _____TechnicalSupervisors { get; set; }
                                public virtual IList<TVSchool_TechnicalSupervisors> TechnicalSupervisors
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<TVSchool_TechnicalSupervisors, Guid>(ref _TechnicalSupervisors, x => x._____TechnicalSupervisors,
                                            ModelRepositories.jah.TVSchool_TechnicalSupervisors_Repository.ListByTVSchoolPK<TVSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.TVSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.TechnicalSupervisors, x => x._____TechnicalSupervisors, _TechnicalSupervisors, value); }
                                }

                                    

                                LoadableVar<IList<TVSchool_TVPrints>> _TVPrints = new LoadableVar<IList<TVSchool_TVPrints>>();
                                public virtual IList<TVSchool_TVPrints> _____TVPrints { get; set; }
                                public virtual IList<TVSchool_TVPrints> TVPrints
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<TVSchool_TVPrints, Guid>(ref _TVPrints, x => x._____TVPrints,
                                            ModelRepositories.jah.TVSchool_TVPrints_Repository.ListByTVSchoolPK<TVSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.TVSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.TVPrints, x => x._____TVPrints, _TVPrints, value); }
                                }

                                    

                                LoadableVar<IList<TVSchool_TypeSetters>> _TypeSetters = new LoadableVar<IList<TVSchool_TypeSetters>>();
                                public virtual IList<TVSchool_TypeSetters> _____TypeSetters { get; set; }
                                public virtual IList<TVSchool_TypeSetters> TypeSetters
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<TVSchool_TypeSetters, Guid>(ref _TypeSetters, x => x._____TypeSetters,
                                            ModelRepositories.jah.TVSchool_TypeSetters_Repository.ListByTVSchoolPK<TVSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.TVSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.TypeSetters, x => x._____TypeSetters, _TypeSetters, value); }
                                }

                                    

                                LoadableVar<IList<TVSchool_Editors>> _Editors = new LoadableVar<IList<TVSchool_Editors>>();
                                public virtual IList<TVSchool_Editors> _____Editors { get; set; }
                                public virtual IList<TVSchool_Editors> Editors
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<TVSchool_Editors, Guid>(ref _Editors, x => x._____Editors,
                                            ModelRepositories.jah.TVSchool_Editors_Repository.ListByTVSchoolPK<TVSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.TVSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Editors, x => x._____Editors, _Editors, value); }
                                }

                                    

                                LoadableVar<IList<TVSchool_PageStylists>> _PageStylists = new LoadableVar<IList<TVSchool_PageStylists>>();
                                public virtual IList<TVSchool_PageStylists> _____PageStylists { get; set; }
                                public virtual IList<TVSchool_PageStylists> PageStylists
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<TVSchool_PageStylists, Guid>(ref _PageStylists, x => x._____PageStylists,
                                            ModelRepositories.jah.TVSchool_PageStylists_Repository.ListByTVSchoolPK<TVSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.TVSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.PageStylists, x => x._____PageStylists, _PageStylists, value); }
                                }

                                    

                                LoadableVar<IList<TVSchool_Graphists>> _Graphists = new LoadableVar<IList<TVSchool_Graphists>>();
                                public virtual IList<TVSchool_Graphists> _____Graphists { get; set; }
                                public virtual IList<TVSchool_Graphists> Graphists
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<TVSchool_Graphists, Guid>(ref _Graphists, x => x._____Graphists,
                                            ModelRepositories.jah.TVSchool_Graphists_Repository.ListByTVSchoolPK<TVSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.TVSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Graphists, x => x._____Graphists, _Graphists, value); }
                                }

                                    

                                LoadableVar<IList<TVSchool_Preparators>> _Preparators = new LoadableVar<IList<TVSchool_Preparators>>();
                                public virtual IList<TVSchool_Preparators> _____Preparators { get; set; }
                                public virtual IList<TVSchool_Preparators> Preparators
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<TVSchool_Preparators, Guid>(ref _Preparators, x => x._____Preparators,
                                            ModelRepositories.jah.TVSchool_Preparators_Repository.ListByTVSchoolPK<TVSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.TVSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Preparators, x => x._____Preparators, _Preparators, value); }
                                }

                                    
public virtual string PublicationDate { get; set; }

public virtual string DistributionDate { get; set; }

public virtual string Tirajh { get; set; }


                                LoadableVar<IList<TVSchool_LitoGraphists>> _LitoGraphists = new LoadableVar<IList<TVSchool_LitoGraphists>>();
                                public virtual IList<TVSchool_LitoGraphists> _____LitoGraphists { get; set; }
                                public virtual IList<TVSchool_LitoGraphists> LitoGraphists
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<TVSchool_LitoGraphists, Guid>(ref _LitoGraphists, x => x._____LitoGraphists,
                                            ModelRepositories.jah.TVSchool_LitoGraphists_Repository.ListByTVSchoolPK<TVSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.TVSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.LitoGraphists, x => x._____LitoGraphists, _LitoGraphists, value); }
                                }

                                    
public virtual string Address { get; set; }

public virtual string Tel { get; set; }

public virtual string Fax { get; set; }

public virtual string PublicationPeriod { get; set; }


                                LoadableVar<IList<TVSchool_BookBinders>> _BookBinders = new LoadableVar<IList<TVSchool_BookBinders>>();
                                public virtual IList<TVSchool_BookBinders> _____BookBinders { get; set; }
                                public virtual IList<TVSchool_BookBinders> BookBinders
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<TVSchool_BookBinders, Guid>(ref _BookBinders, x => x._____BookBinders,
                                            ModelRepositories.jah.TVSchool_BookBinders_Repository.ListByTVSchoolPK<TVSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.TVSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.BookBinders, x => x._____BookBinders, _BookBinders, value); }
                                }

                                    
public virtual string CenterName { get; set; }


                                LoadableVar<IList<TVSchool_Audiences>> _Audiences = new LoadableVar<IList<TVSchool_Audiences>>();
                                public virtual IList<TVSchool_Audiences> _____Audiences { get; set; }
                                public virtual IList<TVSchool_Audiences> Audiences
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<TVSchool_Audiences, Guid>(ref _Audiences, x => x._____Audiences,
                                            ModelRepositories.jah.TVSchool_Audiences_Repository.ListByTVSchoolPK<TVSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.TVSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Audiences, x => x._____Audiences, _Audiences, value); }
                                }

                                    

                                LoadableVar<IList<TVSchool_EducationalGoals>> _EducationalGoals = new LoadableVar<IList<TVSchool_EducationalGoals>>();
                                public virtual IList<TVSchool_EducationalGoals> _____EducationalGoals { get; set; }
                                public virtual IList<TVSchool_EducationalGoals> EducationalGoals
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<TVSchool_EducationalGoals, Guid>(ref _EducationalGoals, x => x._____EducationalGoals,
                                            ModelRepositories.jah.TVSchool_EducationalGoals_Repository.ListByTVSchoolPK<TVSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.TVSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.EducationalGoals, x => x._____EducationalGoals, _EducationalGoals, value); }
                                }

                                    
public override Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion> GetAssociation(string PropertyPath) {





                          if (_GPN(x => x.AddedBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____AddedBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.ModifyBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____ModifyBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            






                          if (_GPN(x => x.Publishers) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Publishers), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Writers) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Writers), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.TechnicalExperts) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____TechnicalExperts), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.TechnicalSupervisors) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____TechnicalSupervisors), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.TVPrints) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____TVPrints), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.TypeSetters) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____TypeSetters), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Editors) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Editors), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.PageStylists) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____PageStylists), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Graphists) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Graphists), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Preparators) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Preparators), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            




                          if (_GPN(x => x.LitoGraphists) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____LitoGraphists), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            





                          if (_GPN(x => x.BookBinders) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____BookBinders), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            


                          if (_GPN(x => x.Audiences) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Audiences), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.EducationalGoals) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____EducationalGoals), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            
return base.GetAssociation(PropertyPath);
}
  public override void LoadFromStringDictionary(Dictionary<string, string> Dic)
        {
         
            if (Dic.ContainsKey(_GPN(x => x.AddedBy.id).ToClientDsFieldName()))
            {
                try
                {
                    this.AddedBy= ModelRepositories.UserRepository.ByPK(Guid.Parse(Dic[_GPN(x => x.AddedBy.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.AddedBy), ref Dic);

                }
                catch { }
            }
                    
            if (Dic.ContainsKey(_GPN(x => x.ModifyBy.id).ToClientDsFieldName()))
            {
                try
                {
                    this.ModifyBy= ModelRepositories.UserRepository.ByPK(Guid.Parse(Dic[_GPN(x => x.ModifyBy.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.ModifyBy), ref Dic);

                }
                catch { }
            }
                    
                        base.LoadFromStringDictionary(Dic);
            }
  
            public override INHibernateEntity LoadByPrimaryKeys(Dictionary<string, object> primarykeys_value)
            {
            if (
                primarykeys_value.Keys.Contains(_GPN(x => x.id))
                && 
                primarykeys_value[_GPN(x => x.id)] != null)
            {
                return ModelRepositories.jah.TVSchool_Repository.ByPK((Guid)primarykeys_value[_GPN(x => x.id)]);
            }
            return null;

            }}
public class TVSchoolLog: LogModelBase<TVSchoolLog>
                                {
                                public virtual DateTime AddDate { get; set; }

public virtual DateTime LastModifyDate { get; set; }


                                            LoadableVar<User> _AddedBy= new LoadableVar<User>();
                                            public virtual User _____AddedBy { get; set; }
                                            public virtual User AddedBy
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<User, Guid>
                                                        (ref _AddedBy,
                                                        x => x._____AddedBy,
                                                        ModelRepositories.UserRepository.ByPK,
                                                        x => x._____AddedBy.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.AddedBy, x => x._____AddedBy, _AddedBy, value);

                                                }
                                            }
                                    

                                            LoadableVar<User> _ModifyBy= new LoadableVar<User>();
                                            public virtual User _____ModifyBy { get; set; }
                                            public virtual User ModifyBy
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<User, Guid>
                                                        (ref _ModifyBy,
                                                        x => x._____ModifyBy,
                                                        ModelRepositories.UserRepository.ByPK,
                                                        x => x._____ModifyBy.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.ModifyBy, x => x._____ModifyBy, _ModifyBy, value);

                                                }
                                            }
                                    
public virtual string Description { get; set; }

public virtual string TVSchoolName { get; set; }

public virtual string TVTitle { get; set; }

public virtual string PublicationNo { get; set; }

public virtual string PublicationCode { get; set; }

public virtual string PublicationDate { get; set; }

public virtual string DistributionDate { get; set; }

public virtual string Tirajh { get; set; }

public virtual string Address { get; set; }

public virtual string Tel { get; set; }

public virtual string Fax { get; set; }

public virtual string PublicationPeriod { get; set; }

public virtual string CenterName { get; set; }

}
}

