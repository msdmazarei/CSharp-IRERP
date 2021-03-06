
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
public class SlideVision:IRERP_RestAPI.Bases.ModelBaseLog<SlideVision, SlideVisionLog>{
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
                                    
public virtual string SlideVisionTime { get; set; }

public virtual string ProductionDate { get; set; }

public virtual string Montage { get; set; }

public virtual string SlideVisionCode { get; set; }


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
                                    

                                LoadableVar<IList<SlideVision_EducationalGoals>> _EducationalGoals = new LoadableVar<IList<SlideVision_EducationalGoals>>();
                                public virtual IList<SlideVision_EducationalGoals> _____EducationalGoals { get; set; }
                                public virtual IList<SlideVision_EducationalGoals> EducationalGoals
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<SlideVision_EducationalGoals, Guid>(ref _EducationalGoals, x => x._____EducationalGoals,
                                            ModelRepositories.jah.SlideVision_EducationalGoals_Repository.ListBySlideVisionPK<SlideVision>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.SlideVision = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.EducationalGoals, x => x._____EducationalGoals, _EducationalGoals, value); }
                                }

                                    

                                LoadableVar<IList<SlideVision_TechnicalExperts>> _TechnicalExperts = new LoadableVar<IList<SlideVision_TechnicalExperts>>();
                                public virtual IList<SlideVision_TechnicalExperts> _____TechnicalExperts { get; set; }
                                public virtual IList<SlideVision_TechnicalExperts> TechnicalExperts
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<SlideVision_TechnicalExperts, Guid>(ref _TechnicalExperts, x => x._____TechnicalExperts,
                                            ModelRepositories.jah.SlideVision_TechnicalExperts_Repository.ListBySlideVisionPK<SlideVision>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.SlideVision = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.TechnicalExperts, x => x._____TechnicalExperts, _TechnicalExperts, value); }
                                }

                                    

                                LoadableVar<IList<SlideVision_Speakers>> _Speakers = new LoadableVar<IList<SlideVision_Speakers>>();
                                public virtual IList<SlideVision_Speakers> _____Speakers { get; set; }
                                public virtual IList<SlideVision_Speakers> Speakers
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<SlideVision_Speakers, Guid>(ref _Speakers, x => x._____Speakers,
                                            ModelRepositories.jah.SlideVision_Speakers_Repository.ListBySlideVisionPK<SlideVision>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.SlideVision = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Speakers, x => x._____Speakers, _Speakers, value); }
                                }

                                    

                                LoadableVar<IList<SlideVision_Senarists>> _Senarists = new LoadableVar<IList<SlideVision_Senarists>>();
                                public virtual IList<SlideVision_Senarists> _____Senarists { get; set; }
                                public virtual IList<SlideVision_Senarists> Senarists
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<SlideVision_Senarists, Guid>(ref _Senarists, x => x._____Senarists,
                                            ModelRepositories.jah.SlideVision_Senarists_Repository.ListBySlideVisionPK<SlideVision>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.SlideVision = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Senarists, x => x._____Senarists, _Senarists, value); }
                                }

                                    

                                LoadableVar<IList<SlideVision_PhotoGraphists>> _PhotoGraphists = new LoadableVar<IList<SlideVision_PhotoGraphists>>();
                                public virtual IList<SlideVision_PhotoGraphists> _____PhotoGraphists { get; set; }
                                public virtual IList<SlideVision_PhotoGraphists> PhotoGraphists
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<SlideVision_PhotoGraphists, Guid>(ref _PhotoGraphists, x => x._____PhotoGraphists,
                                            ModelRepositories.jah.SlideVision_PhotoGraphists_Repository.ListBySlideVisionPK<SlideVision>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.SlideVision = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.PhotoGraphists, x => x._____PhotoGraphists, _PhotoGraphists, value); }
                                }

                                    

                                LoadableVar<IList<SlideVision_Directors>> _Directors = new LoadableVar<IList<SlideVision_Directors>>();
                                public virtual IList<SlideVision_Directors> _____Directors { get; set; }
                                public virtual IList<SlideVision_Directors> Directors
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<SlideVision_Directors, Guid>(ref _Directors, x => x._____Directors,
                                            ModelRepositories.jah.SlideVision_Directors_Repository.ListBySlideVisionPK<SlideVision>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.SlideVision = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Directors, x => x._____Directors, _Directors, value); }
                                }

                                    

                                LoadableVar<IList<SlideVision_Audiences>> _Audiences = new LoadableVar<IList<SlideVision_Audiences>>();
                                public virtual IList<SlideVision_Audiences> _____Audiences { get; set; }
                                public virtual IList<SlideVision_Audiences> Audiences
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<SlideVision_Audiences, Guid>(ref _Audiences, x => x._____Audiences,
                                            ModelRepositories.jah.SlideVision_Audiences_Repository.ListBySlideVisionPK<SlideVision>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.SlideVision = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Audiences, x => x._____Audiences, _Audiences, value); }
                                }

                                    
public virtual string ProductedIn { get; set; }

public override Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion> GetAssociation(string PropertyPath) {





                          if (_GPN(x => x.AddedBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____AddedBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.ModifyBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____ModifyBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            


                          if (_GPN(x => x.Title) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Title), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            





                          if (_GPN(x => x.ProductionFormat) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____ProductionFormat), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Client) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Client), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.EducationalGoals) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____EducationalGoals), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.TechnicalExperts) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____TechnicalExperts), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Speakers) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Speakers), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Senarists) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Senarists), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.PhotoGraphists) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____PhotoGraphists), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Directors) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Directors), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Audiences) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Audiences), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

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
                    
                        base.LoadFromStringDictionary(Dic);
            }
  
            public override INHibernateEntity LoadByPrimaryKeys(Dictionary<string, object> primarykeys_value)
            {
            if (
                primarykeys_value.Keys.Contains(_GPN(x => x.id))
                && 
                primarykeys_value[_GPN(x => x.id)] != null)
            {
                return ModelRepositories.jah.SlideVision_Repository.ByPK((Guid)primarykeys_value[_GPN(x => x.id)]);
            }
            return null;

            }}
public class SlideVisionLog: LogModelBase<SlideVisionLog>
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
                                    
public virtual string SlideVisionTime { get; set; }

public virtual string ProductionDate { get; set; }

public virtual string Montage { get; set; }

public virtual string SlideVisionCode { get; set; }


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
                                    
public virtual string ProductedIn { get; set; }

}
}

