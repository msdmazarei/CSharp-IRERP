
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
public class PlayShow:IRERP_RestAPI.Bases.ModelBaseLog<PlayShow, PlayShowLog>{
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


                                            LoadableVar<Title> _Title= new LoadableVar<Title>();
                                            public virtual Title _____Title { get; set; }
                                            public virtual Title Title
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Title, Guid>
                                                        (ref _Title,
                                                        x => x._____Title,
                                                        ModelRepositories.jah.Title_Repository.ByPK,
                                                        x => x._____Title.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.Title, x => x._____Title, _Title, value);

                                                }
                                            }
                                    
public virtual string PlayShowTime { get; set; }

public virtual string Center { get; set; }

public virtual string PlayShowCode { get; set; }


                                LoadableVar<IList<PlayShow_EducationalGoals>> _EducationalGoals = new LoadableVar<IList<PlayShow_EducationalGoals>>();
                                public virtual IList<PlayShow_EducationalGoals> _____EducationalGoals { get; set; }
                                public virtual IList<PlayShow_EducationalGoals> EducationalGoals
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<PlayShow_EducationalGoals, Guid>(ref _EducationalGoals, x => x._____EducationalGoals,
                                            ModelRepositories.jah.PlayShow_EducationalGoals_Repository.ListByPlayShowPK<PlayShow>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.PlayShow = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.EducationalGoals, x => x._____EducationalGoals, _EducationalGoals, value); }
                                }

                                    

                                LoadableVar<IList<PlayShow_TechnicalExperts>> _TechnicalExperts = new LoadableVar<IList<PlayShow_TechnicalExperts>>();
                                public virtual IList<PlayShow_TechnicalExperts> _____TechnicalExperts { get; set; }
                                public virtual IList<PlayShow_TechnicalExperts> TechnicalExperts
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<PlayShow_TechnicalExperts, Guid>(ref _TechnicalExperts, x => x._____TechnicalExperts,
                                            ModelRepositories.jah.PlayShow_TechnicalExperts_Repository.ListByPlayShowPK<PlayShow>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.PlayShow = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.TechnicalExperts, x => x._____TechnicalExperts, _TechnicalExperts, value); }
                                }

                                    

                                LoadableVar<IList<PlayShow_Speakers>> _Speakers = new LoadableVar<IList<PlayShow_Speakers>>();
                                public virtual IList<PlayShow_Speakers> _____Speakers { get; set; }
                                public virtual IList<PlayShow_Speakers> Speakers
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<PlayShow_Speakers, Guid>(ref _Speakers, x => x._____Speakers,
                                            ModelRepositories.jah.PlayShow_Speakers_Repository.ListByPlayShowPK<PlayShow>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.PlayShow = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Speakers, x => x._____Speakers, _Speakers, value); }
                                }

                                    

                                LoadableVar<IList<PlayShow_Actors>> _Actors = new LoadableVar<IList<PlayShow_Actors>>();
                                public virtual IList<PlayShow_Actors> _____Actors { get; set; }
                                public virtual IList<PlayShow_Actors> Actors
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<PlayShow_Actors, Guid>(ref _Actors, x => x._____Actors,
                                            ModelRepositories.jah.PlayShow_Actors_Repository.ListByPlayShowPK<PlayShow>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.PlayShow = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Actors, x => x._____Actors, _Actors, value); }
                                }

                                    

                                LoadableVar<IList<PlayShow_Writers>> _Writers = new LoadableVar<IList<PlayShow_Writers>>();
                                public virtual IList<PlayShow_Writers> _____Writers { get; set; }
                                public virtual IList<PlayShow_Writers> Writers
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<PlayShow_Writers, Guid>(ref _Writers, x => x._____Writers,
                                            ModelRepositories.jah.PlayShow_Writers_Repository.ListByPlayShowPK<PlayShow>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.PlayShow = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Writers, x => x._____Writers, _Writers, value); }
                                }

                                    

                                LoadableVar<IList<PlayShow_Directors>> _Directors = new LoadableVar<IList<PlayShow_Directors>>();
                                public virtual IList<PlayShow_Directors> _____Directors { get; set; }
                                public virtual IList<PlayShow_Directors> Directors
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<PlayShow_Directors, Guid>(ref _Directors, x => x._____Directors,
                                            ModelRepositories.jah.PlayShow_Directors_Repository.ListByPlayShowPK<PlayShow>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.PlayShow = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Directors, x => x._____Directors, _Directors, value); }
                                }

                                    

                                LoadableVar<IList<PlayShow_Producers>> _Producers = new LoadableVar<IList<PlayShow_Producers>>();
                                public virtual IList<PlayShow_Producers> _____Producers { get; set; }
                                public virtual IList<PlayShow_Producers> Producers
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<PlayShow_Producers, Guid>(ref _Producers, x => x._____Producers,
                                            ModelRepositories.jah.PlayShow_Producers_Repository.ListByPlayShowPK<PlayShow>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.PlayShow = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Producers, x => x._____Producers, _Producers, value); }
                                }

                                    

                                LoadableVar<IList<PlayShow_Audiences>> _Audiences = new LoadableVar<IList<PlayShow_Audiences>>();
                                public virtual IList<PlayShow_Audiences> _____Audiences { get; set; }
                                public virtual IList<PlayShow_Audiences> Audiences
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<PlayShow_Audiences, Guid>(ref _Audiences, x => x._____Audiences,
                                            ModelRepositories.jah.PlayShow_Audiences_Repository.ListByPlayShowPK<PlayShow>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.PlayShow = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Audiences, x => x._____Audiences, _Audiences, value); }
                                }

                                    

                                LoadableVar<IList<PlayShowContentlist>> _PlayShowContentlists = new LoadableVar<IList<PlayShowContentlist>>();
                                public virtual IList<PlayShowContentlist> _____PlayShowContentlists { get; set; }
                                public virtual IList<PlayShowContentlist> PlayShowContentlists
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<PlayShowContentlist, Guid>(ref _PlayShowContentlists, x => x._____PlayShowContentlists,
                                            ModelRepositories.jah.PlayShowContentlist_Repository.ListByPlayShowPK<PlayShow>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.PlayShow = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.PlayShowContentlists, x => x._____PlayShowContentlists, _PlayShowContentlists, value); }
                                }

                                    
public override Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion> GetAssociation(string PropertyPath) {





                          if (_GPN(x => x.AddedBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____AddedBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.ModifyBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____ModifyBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            


                          if (_GPN(x => x.Title) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Title), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            




                          if (_GPN(x => x.EducationalGoals) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____EducationalGoals), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.TechnicalExperts) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____TechnicalExperts), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Speakers) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Speakers), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Actors) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Actors), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Writers) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Writers), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Directors) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Directors), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Producers) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Producers), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Audiences) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Audiences), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.PlayShowContentlists) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____PlayShowContentlists), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            
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
                    
            if (Dic.ContainsKey(_GPN(x => x.Title.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Title= ModelRepositories.jah.Title_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.Title.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.Title), ref Dic);

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
                return ModelRepositories.jah.PlayShow_Repository.ByPK((Guid)primarykeys_value[_GPN(x => x.id)]);
            }
            return null;

            }}
public class PlayShowLog: LogModelBase<PlayShowLog>
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


                                            LoadableVar<Title> _Title= new LoadableVar<Title>();
                                            public virtual Title _____Title { get; set; }
                                            public virtual Title Title
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Title, Guid>
                                                        (ref _Title,
                                                        x => x._____Title,
                                                        ModelRepositories.jah.Title_Repository.ByPK,
                                                        x => x._____Title.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.Title, x => x._____Title, _Title, value);

                                                }
                                            }
                                    
public virtual string PlayShowTime { get; set; }

public virtual string Center { get; set; }

public virtual string PlayShowCode { get; set; }

}
}

