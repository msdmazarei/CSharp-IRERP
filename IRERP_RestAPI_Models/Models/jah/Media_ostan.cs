
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
public class Media_ostan:IRERP_RestAPI.Bases.ModelBase<Media_ostan>
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


                                            LoadableVar<Media> _Media= new LoadableVar<Media>();
                                            public virtual Media _____Media { get; set; }
                                            public virtual Media Media
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Media, Guid>
                                                        (ref _Media,
                                                        x => x._____Media,
                                                        ModelRepositories.jah.Media_Repository.ByPK,
                                                        x => x._____Media.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.Media, x => x._____Media, _Media, value);

                                                }
                                            }
                                    

                                            LoadableVar<State> _State= new LoadableVar<State>();
                                            public virtual State _____State { get; set; }
                                            public virtual State State
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<State, Guid>
                                                        (ref _State,
                                                        x => x._____State,
                                                        ModelRepositories.jah.State_Repository.ByPK,
                                                        x => x._____State.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.State, x => x._____State, _State, value);

                                                }
                                            }
                                    
public override Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion> GetAssociation(string PropertyPath) {





                          if (_GPN(x => x.AddedBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____AddedBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.ModifyBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____ModifyBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            


                          if (_GPN(x => x.Media) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Media), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.State) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____State), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            
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
                    
            if (Dic.ContainsKey(_GPN(x => x.Media.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Media= ModelRepositories.jah.Media_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.Media.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.Media), ref Dic);

                }
                catch { }
            }
                    
            if (Dic.ContainsKey(_GPN(x => x.State.id).ToClientDsFieldName()))
            {
                try
                {
                    this.State= ModelRepositories.jah.State_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.State.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.State), ref Dic);

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
                return ModelRepositories.jah.Media_ostan_Repository.ByPK((Guid)primarykeys_value[_GPN(x => x.id)]);
            }
            return null;

            }}
}

