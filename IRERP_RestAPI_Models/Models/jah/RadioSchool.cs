
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
public class RadioSchool:IRERP_RestAPI.Bases.ModelBaseLog<RadioSchool, RadioSchoolLog>{
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

public virtual string RadioSchoolName { get; set; }

public virtual string PublicationNo { get; set; }

public virtual string PublicationCode { get; set; }


                                LoadableVar<IList<RadioSchool_Publishers>> _Publishers = new LoadableVar<IList<RadioSchool_Publishers>>();
                                public virtual IList<RadioSchool_Publishers> _____Publishers { get; set; }
                                public virtual IList<RadioSchool_Publishers> Publishers
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<RadioSchool_Publishers, Guid>(ref _Publishers, x => x._____Publishers,
                                            ModelRepositories.jah.RadioSchool_Publishers_Repository.ListByRadioSchoolPK<RadioSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.RadioSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Publishers, x => x._____Publishers, _Publishers, value); }
                                }

                                    

                                LoadableVar<IList<RadioSchool_Writers>> _Writers = new LoadableVar<IList<RadioSchool_Writers>>();
                                public virtual IList<RadioSchool_Writers> _____Writers { get; set; }
                                public virtual IList<RadioSchool_Writers> Writers
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<RadioSchool_Writers, Guid>(ref _Writers, x => x._____Writers,
                                            ModelRepositories.jah.RadioSchool_Writers_Repository.ListByRadioSchoolPK<RadioSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.RadioSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Writers, x => x._____Writers, _Writers, value); }
                                }

                                    

                                LoadableVar<IList<RadioSchool_TechnicalExperts>> _TechnicalExperts = new LoadableVar<IList<RadioSchool_TechnicalExperts>>();
                                public virtual IList<RadioSchool_TechnicalExperts> _____TechnicalExperts { get; set; }
                                public virtual IList<RadioSchool_TechnicalExperts> TechnicalExperts
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<RadioSchool_TechnicalExperts, Guid>(ref _TechnicalExperts, x => x._____TechnicalExperts,
                                            ModelRepositories.jah.RadioSchool_TechnicalExperts_Repository.ListByRadioSchoolPK<RadioSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.RadioSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.TechnicalExperts, x => x._____TechnicalExperts, _TechnicalExperts, value); }
                                }

                                    

                                LoadableVar<IList<RadioSchool_TechnicalSupervisors>> _TechnicalSupervisors = new LoadableVar<IList<RadioSchool_TechnicalSupervisors>>();
                                public virtual IList<RadioSchool_TechnicalSupervisors> _____TechnicalSupervisors { get; set; }
                                public virtual IList<RadioSchool_TechnicalSupervisors> TechnicalSupervisors
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<RadioSchool_TechnicalSupervisors, Guid>(ref _TechnicalSupervisors, x => x._____TechnicalSupervisors,
                                            ModelRepositories.jah.RadioSchool_TechnicalSupervisors_Repository.ListByRadioSchoolPK<RadioSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.RadioSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.TechnicalSupervisors, x => x._____TechnicalSupervisors, _TechnicalSupervisors, value); }
                                }

                                    

                                LoadableVar<IList<RadioSchool_RadioPrints>> _RadioPrints = new LoadableVar<IList<RadioSchool_RadioPrints>>();
                                public virtual IList<RadioSchool_RadioPrints> _____RadioPrints { get; set; }
                                public virtual IList<RadioSchool_RadioPrints> RadioPrints
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<RadioSchool_RadioPrints, Guid>(ref _RadioPrints, x => x._____RadioPrints,
                                            ModelRepositories.jah.RadioSchool_RadioPrints_Repository.ListByRadioSchoolPK<RadioSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.RadioSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.RadioPrints, x => x._____RadioPrints, _RadioPrints, value); }
                                }

                                    

                                LoadableVar<IList<RadioSchool_TypeSetters>> _TypeSetters = new LoadableVar<IList<RadioSchool_TypeSetters>>();
                                public virtual IList<RadioSchool_TypeSetters> _____TypeSetters { get; set; }
                                public virtual IList<RadioSchool_TypeSetters> TypeSetters
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<RadioSchool_TypeSetters, Guid>(ref _TypeSetters, x => x._____TypeSetters,
                                            ModelRepositories.jah.RadioSchool_TypeSetters_Repository.ListByRadioSchoolPK<RadioSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.RadioSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.TypeSetters, x => x._____TypeSetters, _TypeSetters, value); }
                                }

                                    

                                LoadableVar<IList<RadioSchool_Editors>> _Editors = new LoadableVar<IList<RadioSchool_Editors>>();
                                public virtual IList<RadioSchool_Editors> _____Editors { get; set; }
                                public virtual IList<RadioSchool_Editors> Editors
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<RadioSchool_Editors, Guid>(ref _Editors, x => x._____Editors,
                                            ModelRepositories.jah.RadioSchool_Editors_Repository.ListByRadioSchoolPK<RadioSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.RadioSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Editors, x => x._____Editors, _Editors, value); }
                                }

                                    

                                LoadableVar<IList<RadioSchool_PageStylists>> _PageStylists = new LoadableVar<IList<RadioSchool_PageStylists>>();
                                public virtual IList<RadioSchool_PageStylists> _____PageStylists { get; set; }
                                public virtual IList<RadioSchool_PageStylists> PageStylists
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<RadioSchool_PageStylists, Guid>(ref _PageStylists, x => x._____PageStylists,
                                            ModelRepositories.jah.RadioSchool_PageStylists_Repository.ListByRadioSchoolPK<RadioSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.RadioSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.PageStylists, x => x._____PageStylists, _PageStylists, value); }
                                }

                                    

                                LoadableVar<IList<RadioSchool_Graphists>> _Graphists = new LoadableVar<IList<RadioSchool_Graphists>>();
                                public virtual IList<RadioSchool_Graphists> _____Graphists { get; set; }
                                public virtual IList<RadioSchool_Graphists> Graphists
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<RadioSchool_Graphists, Guid>(ref _Graphists, x => x._____Graphists,
                                            ModelRepositories.jah.RadioSchool_Graphists_Repository.ListByRadioSchoolPK<RadioSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.RadioSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Graphists, x => x._____Graphists, _Graphists, value); }
                                }

                                    
public virtual string PublicationDate { get; set; }

public virtual string DistributionDate { get; set; }

public virtual string Tirajh { get; set; }


                                LoadableVar<IList<RadioSchool_LitoGraphists>> _LitoGraphists = new LoadableVar<IList<RadioSchool_LitoGraphists>>();
                                public virtual IList<RadioSchool_LitoGraphists> _____LitoGraphists { get; set; }
                                public virtual IList<RadioSchool_LitoGraphists> LitoGraphists
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<RadioSchool_LitoGraphists, Guid>(ref _LitoGraphists, x => x._____LitoGraphists,
                                            ModelRepositories.jah.RadioSchool_LitoGraphists_Repository.ListByRadioSchoolPK<RadioSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.RadioSchool = x;
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


                                LoadableVar<IList<RadioSchool_BookBinders>> _BookBinders = new LoadableVar<IList<RadioSchool_BookBinders>>();
                                public virtual IList<RadioSchool_BookBinders> _____BookBinders { get; set; }
                                public virtual IList<RadioSchool_BookBinders> BookBinders
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<RadioSchool_BookBinders, Guid>(ref _BookBinders, x => x._____BookBinders,
                                            ModelRepositories.jah.RadioSchool_BookBinders_Repository.ListByRadioSchoolPK<RadioSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.RadioSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.BookBinders, x => x._____BookBinders, _BookBinders, value); }
                                }

                                    
public virtual string CenterName { get; set; }


                                LoadableVar<IList<RadioSchool_Audiences>> _Audiences = new LoadableVar<IList<RadioSchool_Audiences>>();
                                public virtual IList<RadioSchool_Audiences> _____Audiences { get; set; }
                                public virtual IList<RadioSchool_Audiences> Audiences
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<RadioSchool_Audiences, Guid>(ref _Audiences, x => x._____Audiences,
                                            ModelRepositories.jah.RadioSchool_Audiences_Repository.ListByRadioSchoolPK<RadioSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.RadioSchool = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Audiences, x => x._____Audiences, _Audiences, value); }
                                }

                                    

                                LoadableVar<IList<RadioSchool_EducationalGoals>> _EducationalGoals = new LoadableVar<IList<RadioSchool_EducationalGoals>>();
                                public virtual IList<RadioSchool_EducationalGoals> _____EducationalGoals { get; set; }
                                public virtual IList<RadioSchool_EducationalGoals> EducationalGoals
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<RadioSchool_EducationalGoals, Guid>(ref _EducationalGoals, x => x._____EducationalGoals,
                                            ModelRepositories.jah.RadioSchool_EducationalGoals_Repository.ListByRadioSchoolPK<RadioSchool>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.RadioSchool = x;
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

                            

                          if (_GPN(x => x.RadioPrints) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____RadioPrints), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.TypeSetters) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____TypeSetters), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Editors) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Editors), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.PageStylists) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____PageStylists), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Graphists) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Graphists), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            




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
                return ModelRepositories.jah.RadioSchool_Repository.ByPK((Guid)primarykeys_value[_GPN(x => x.id)]);
            }
            return null;

            }}
public class RadioSchoolLog: LogModelBase<RadioSchoolLog>
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

public virtual string RadioSchoolName { get; set; }

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

