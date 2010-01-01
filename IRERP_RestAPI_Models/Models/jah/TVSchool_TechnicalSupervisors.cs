
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
public class TVSchool_TechnicalSupervisors:IRERP_RestAPI.Bases.ModelBase<TVSchool_TechnicalSupervisors>
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


                                            LoadableVar<TVSchool> _TVSchool= new LoadableVar<TVSchool>();
                                            public virtual TVSchool _____TVSchool { get; set; }
                                            public virtual TVSchool TVSchool
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<TVSchool, Guid>
                                                        (ref _TVSchool,
                                                        x => x._____TVSchool,
                                                        ModelRepositories.jah.TVSchool_Repository.ByPK,
                                                        x => x._____TVSchool.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.TVSchool, x => x._____TVSchool, _TVSchool, value);

                                                }
                                            }
                                    

                                            LoadableVar<Character> _Character= new LoadableVar<Character>();
                                            public virtual Character _____Character { get; set; }
                                            public virtual Character Character
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Character, Guid>
                                                        (ref _Character,
                                                        x => x._____Character,
                                                        ModelRepositories.Bases.Character_Repository.ByPK,
                                                        x => x._____Character.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.Character, x => x._____Character, _Character, value);

                                                }
                                            }
                                    
public override Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion> GetAssociation(string PropertyPath) {





                          if (_GPN(x => x.AddedBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____AddedBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.ModifyBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____ModifyBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            


                          if (_GPN(x => x.TVSchool) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____TVSchool), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Character) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Character), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            
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
                    
            if (Dic.ContainsKey(_GPN(x => x.TVSchool.id).ToClientDsFieldName()))
            {
                try
                {
                    this.TVSchool= ModelRepositories.jah.TVSchool_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.TVSchool.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.TVSchool), ref Dic);

                }
                catch { }
            }
                    
            if (Dic.ContainsKey(_GPN(x => x.Character.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Character= ModelRepositories.Bases.Character_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.Character.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.Character), ref Dic);

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
                return ModelRepositories.jah.TVSchool_TechnicalSupervisors_Repository.ByPK((Guid)primarykeys_value[_GPN(x => x.id)]);
            }
            return null;

            }}
}

