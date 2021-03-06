
using IRERP_RestAPI.Bases;
using MsdLib.CSharp.DALCore;
using MsdLib.Types;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using MsdLib.ExtentionFuncs.Strings;
using System.Linq;
using IRERP_RestAPI.Models.jah;
using IRERP_RestAPI.Models.Bases;
namespace IRERP_RestAPI.Models.jah{
public class Film:IRERP_RestAPI.Bases.ModelBase<Film>
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

public virtual string FilmName { get; set; }

public virtual string FilmTime { get; set; }

public virtual DateTime? ProductionDate { get; set; }

public virtual string PersianProductionDate { get; set; }

public virtual string Montage { get; set; }

public virtual string FilmCode { get; set; }

public virtual string FilmabstracFile { get; set; }


                                            LoadableVar<FilmProductionFormat> _ProductionFormat= new LoadableVar<FilmProductionFormat>();
                                            public virtual FilmProductionFormat _____ProductionFormat { get; set; }
                                            public virtual FilmProductionFormat ProductionFormat
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<FilmProductionFormat, Guid>
                                                        (ref _ProductionFormat,
                                                        x => x._____ProductionFormat,
                                                        ModelRepositories.jah.FilmProductionFormat_Repository.ByPK,
                                                        x => x._____ProductionFormat.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.ProductionFormat, x => x._____ProductionFormat, _ProductionFormat, value);

                                                }
                                            }
                                    

                                            LoadableVar<Character> _Client= new LoadableVar<Character>();
                                            public virtual Character _____Client { get; set; }
                                            public virtual Character Client
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Character, Guid>
                                                        (ref _Client,
                                                        x => x._____Client,
                                                        ModelRepositories.Bases.Character_Repository.ByPK,
                                                        x => x._____Client.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.Client, x => x._____Client, _Client, value);

                                                }
                                            }
                                    

                                            LoadableVar<FilmSystemType> _SystemType= new LoadableVar<FilmSystemType>();
                                            public virtual FilmSystemType _____SystemType { get; set; }
                                            public virtual FilmSystemType SystemType
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<FilmSystemType, Guid>
                                                        (ref _SystemType,
                                                        x => x._____SystemType,
                                                        ModelRepositories.jah.FilmSystemType_Repository.ByPK,
                                                        x => x._____SystemType.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.SystemType, x => x._____SystemType, _SystemType, value);

                                                }
                                            }
                                    

                                LoadableVar<IList<Film_Executives>> _Executives = new LoadableVar<IList<Film_Executives>>();
                                public virtual IList<Film_Executives> _____Executives { get; set; }
                                public virtual IList<Film_Executives> Executives
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<Film_Executives, Guid>(ref _Executives, x => x._____Executives,
                                            ModelRepositories.jah.Film_Executives_Repository.ListByFilmPK<Film>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.Film = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Executives, x => x._____Executives, _Executives, value); }
                                }

                                    

                                LoadableVar<IList<FilmContentlist>> _FilmContentlists = new LoadableVar<IList<FilmContentlist>>();
                                public virtual IList<FilmContentlist> _____FilmContentlists { get; set; }
                                public virtual IList<FilmContentlist> FilmContentlists
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<FilmContentlist, Guid>(ref _FilmContentlists, x => x._____FilmContentlists,
                                            ModelRepositories.jah.FilmContentlist_Repository.ListByFilmPK<Film>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.Film = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.FilmContentlists, x => x._____FilmContentlists, _FilmContentlists, value); }
                                }

                                    

                                LoadableVar<IList<Film_EducationalGoals>> _EducationalGoals = new LoadableVar<IList<Film_EducationalGoals>>();
                                public virtual IList<Film_EducationalGoals> _____EducationalGoals { get; set; }
                                public virtual IList<Film_EducationalGoals> EducationalGoals
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<Film_EducationalGoals, Guid>(ref _EducationalGoals, x => x._____EducationalGoals,
                                            ModelRepositories.jah.Film_EducationalGoals_Repository.ListByFilmPK<Film>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.Film = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.EducationalGoals, x => x._____EducationalGoals, _EducationalGoals, value); }
                                }

                                    

                                LoadableVar<IList<Film_TechnicalExperts>> _TechnicalExperts = new LoadableVar<IList<Film_TechnicalExperts>>();
                                public virtual IList<Film_TechnicalExperts> _____TechnicalExperts { get; set; }
                                public virtual IList<Film_TechnicalExperts> TechnicalExperts
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<Film_TechnicalExperts, Guid>(ref _TechnicalExperts, x => x._____TechnicalExperts,
                                            ModelRepositories.jah.Film_TechnicalExperts_Repository.ListByFilmPK<Film>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.Film = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.TechnicalExperts, x => x._____TechnicalExperts, _TechnicalExperts, value); }
                                }

                                    

                                LoadableVar<IList<Film_Speakers>> _Speakers = new LoadableVar<IList<Film_Speakers>>();
                                public virtual IList<Film_Speakers> _____Speakers { get; set; }
                                public virtual IList<Film_Speakers> Speakers
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<Film_Speakers, Guid>(ref _Speakers, x => x._____Speakers,
                                            ModelRepositories.jah.Film_Speakers_Repository.ListByFilmPK<Film>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.Film = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Speakers, x => x._____Speakers, _Speakers, value); }
                                }

                                    

                                LoadableVar<IList<Film_Senarists>> _Senarists = new LoadableVar<IList<Film_Senarists>>();
                                public virtual IList<Film_Senarists> _____Senarists { get; set; }
                                public virtual IList<Film_Senarists> Senarists
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<Film_Senarists, Guid>(ref _Senarists, x => x._____Senarists,
                                            ModelRepositories.jah.Film_Senarists_Repository.ListByFilmPK<Film>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.Film = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Senarists, x => x._____Senarists, _Senarists, value); }
                                }

                                    

                                LoadableVar<IList<Film_Actors>> _Actors = new LoadableVar<IList<Film_Actors>>();
                                public virtual IList<Film_Actors> _____Actors { get; set; }
                                public virtual IList<Film_Actors> Actors
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<Film_Actors, Guid>(ref _Actors, x => x._____Actors,
                                            ModelRepositories.jah.Film_Actors_Repository.ListByFilmPK<Film>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.Film = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Actors, x => x._____Actors, _Actors, value); }
                                }

                                    

                                LoadableVar<IList<Film_Writers>> _Writers = new LoadableVar<IList<Film_Writers>>();
                                public virtual IList<Film_Writers> _____Writers { get; set; }
                                public virtual IList<Film_Writers> Writers
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<Film_Writers, Guid>(ref _Writers, x => x._____Writers,
                                            ModelRepositories.jah.Film_Writers_Repository.ListByFilmPK<Film>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.Film = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Writers, x => x._____Writers, _Writers, value); }
                                }

                                    

                                LoadableVar<IList<Film_Directors>> _Directors = new LoadableVar<IList<Film_Directors>>();
                                public virtual IList<Film_Directors> _____Directors { get; set; }
                                public virtual IList<Film_Directors> Directors
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<Film_Directors, Guid>(ref _Directors, x => x._____Directors,
                                            ModelRepositories.jah.Film_Directors_Repository.ListByFilmPK<Film>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.Film = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Directors, x => x._____Directors, _Directors, value); }
                                }

                                    
public override Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion> GetAssociation(string PropertyPath) {





                          if (_GPN(x => x.AddedBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____AddedBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.ModifyBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____ModifyBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            









                          if (_GPN(x => x.ProductionFormat) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____ProductionFormat), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Client) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Client), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.SystemType) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____SystemType), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Executives) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Executives), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.FilmContentlists) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____FilmContentlists), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.EducationalGoals) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____EducationalGoals), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.TechnicalExperts) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____TechnicalExperts), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Speakers) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Speakers), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Senarists) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Senarists), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Actors) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Actors), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Writers) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Writers), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Directors) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Directors), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            
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
                    
            if (Dic.ContainsKey(_GPN(x => x.ProductionFormat.id).ToClientDsFieldName()))
            {
                try
                {
                    this.ProductionFormat= ModelRepositories.jah.FilmProductionFormat_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.ProductionFormat.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.ProductionFormat), ref Dic);

                }
                catch { }
            }
                    
            if (Dic.ContainsKey(_GPN(x => x.Client.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Client= ModelRepositories.Bases.Character_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.Client.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.Client), ref Dic);

                }
                catch { }
            }
                    
            if (Dic.ContainsKey(_GPN(x => x.SystemType.id).ToClientDsFieldName()))
            {
                try
                {
                    this.SystemType= ModelRepositories.jah.FilmSystemType_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.SystemType.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.SystemType), ref Dic);

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
                return ModelRepositories.jah.Film_Repository.ByPK((Guid)primarykeys_value[_GPN(x => x.id)]);
            }
            return null;

            }}
}

