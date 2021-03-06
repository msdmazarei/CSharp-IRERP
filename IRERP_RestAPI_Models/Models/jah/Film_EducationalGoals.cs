
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
public class Film_EducationalGoals:IRERP_RestAPI.Bases.ModelBase<Film_EducationalGoals>
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


                                            LoadableVar<Film> _Film= new LoadableVar<Film>();
                                            public virtual Film _____Film { get; set; }
                                            public virtual Film Film
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Film, Guid>
                                                        (ref _Film,
                                                        x => x._____Film,
                                                        ModelRepositories.jah.Film_Repository.ByPK,
                                                        x => x._____Film.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.Film, x => x._____Film, _Film, value);

                                                }
                                            }
                                    

                                            LoadableVar<FilmEducationalGoal> _FilmEducationalGoal= new LoadableVar<FilmEducationalGoal>();
                                            public virtual FilmEducationalGoal _____FilmEducationalGoal { get; set; }
                                            public virtual FilmEducationalGoal FilmEducationalGoal
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<FilmEducationalGoal, Guid>
                                                        (ref _FilmEducationalGoal,
                                                        x => x._____FilmEducationalGoal,
                                                        ModelRepositories.jah.FilmEducationalGoal_Repository.ByPK,
                                                        x => x._____FilmEducationalGoal.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.FilmEducationalGoal, x => x._____FilmEducationalGoal, _FilmEducationalGoal, value);

                                                }
                                            }
                                    
public override Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion> GetAssociation(string PropertyPath) {





                          if (_GPN(x => x.AddedBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____AddedBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.ModifyBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____ModifyBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            


                          if (_GPN(x => x.Film) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Film), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.FilmEducationalGoal) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____FilmEducationalGoal), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            
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
                    
            if (Dic.ContainsKey(_GPN(x => x.Film.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Film= ModelRepositories.jah.Film_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.Film.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.Film), ref Dic);

                }
                catch { }
            }
                    
            if (Dic.ContainsKey(_GPN(x => x.FilmEducationalGoal.id).ToClientDsFieldName()))
            {
                try
                {
                    this.FilmEducationalGoal= ModelRepositories.jah.FilmEducationalGoal_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.FilmEducationalGoal.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.FilmEducationalGoal), ref Dic);

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
                return ModelRepositories.jah.Film_EducationalGoals_Repository.ByPK((Guid)primarykeys_value[_GPN(x => x.id)]);
            }
            return null;

            }}
}

