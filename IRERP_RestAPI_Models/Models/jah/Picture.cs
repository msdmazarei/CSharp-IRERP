
using IRERP_RestAPI.Bases;
using MsdLib.CSharp.DALCore;
using MsdLib.Types;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using MsdLib.ExtentionFuncs.Strings;
using System.Linq;
using IRERP_RestAPI.Models.Bases;
using IRERP_RestAPI.Models.jah;
namespace IRERP_RestAPI.Models.jah{
public class Picture:IRERP_RestAPI.Bases.ModelBaseLog<Picture, PictureLog>{
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

public virtual string piccode { get; set; }

public virtual string shotdate { get; set; }


                                            LoadableVar<Character> _client= new LoadableVar<Character>();
                                            public virtual Character _____client { get; set; }
                                            public virtual Character client
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Character, Guid>
                                                        (ref _client,
                                                        x => x._____client,
                                                        ModelRepositories.Bases.Character_Repository.ByPK,
                                                        x => x._____client.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.client, x => x._____client, _client, value);

                                                }
                                            }
                                    

                                            LoadableVar<Title> _title= new LoadableVar<Title>();
                                            public virtual Title _____title { get; set; }
                                            public virtual Title title
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Title, Guid>
                                                        (ref _title,
                                                        x => x._____title,
                                                        ModelRepositories.jah.Title_Repository.ByPK,
                                                        x => x._____title.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.title, x => x._____title, _title, value);

                                                }
                                            }
                                    

                                            LoadableVar<Size> _Size= new LoadableVar<Size>();
                                            public virtual Size _____Size { get; set; }
                                            public virtual Size Size
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Size, Guid>
                                                        (ref _Size,
                                                        x => x._____Size,
                                                        ModelRepositories.jah.Size_Repository.ByPK,
                                                        x => x._____Size.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.Size, x => x._____Size, _Size, value);

                                                }
                                            }
                                    

                                            LoadableVar<Resulation> _resulation= new LoadableVar<Resulation>();
                                            public virtual Resulation _____resulation { get; set; }
                                            public virtual Resulation resulation
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Resulation, Guid>
                                                        (ref _resulation,
                                                        x => x._____resulation,
                                                        ModelRepositories.jah.Resulation_Repository.ByPK,
                                                        x => x._____resulation.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.resulation, x => x._____resulation, _resulation, value);

                                                }
                                            }
                                    
public virtual string Location { get; set; }


                                            LoadableVar<Character> _Photographer= new LoadableVar<Character>();
                                            public virtual Character _____Photographer { get; set; }
                                            public virtual Character Photographer
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Character, Guid>
                                                        (ref _Photographer,
                                                        x => x._____Photographer,
                                                        ModelRepositories.Bases.Character_Repository.ByPK,
                                                        x => x._____Photographer.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.Photographer, x => x._____Photographer, _Photographer, value);

                                                }
                                            }
                                    

                                            LoadableVar<PictureType> _pictype= new LoadableVar<PictureType>();
                                            public virtual PictureType _____pictype { get; set; }
                                            public virtual PictureType pictype
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<PictureType, Guid>
                                                        (ref _pictype,
                                                        x => x._____pictype,
                                                        ModelRepositories.jah.PictureType_Repository.ByPK,
                                                        x => x._____pictype.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.pictype, x => x._____pictype, _pictype, value);

                                                }
                                            }
                                    

                                            LoadableVar<PictureFormat> _picformat= new LoadableVar<PictureFormat>();
                                            public virtual PictureFormat _____picformat { get; set; }
                                            public virtual PictureFormat picformat
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<PictureFormat, Guid>
                                                        (ref _picformat,
                                                        x => x._____picformat,
                                                        ModelRepositories.jah.PictureFormat_Repository.ByPK,
                                                        x => x._____picformat.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.picformat, x => x._____picformat, _picformat, value);

                                                }
                                            }
                                    
public override Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion> GetAssociation(string PropertyPath) {





                          if (_GPN(x => x.AddedBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____AddedBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.ModifyBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____ModifyBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            




                          if (_GPN(x => x.client) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____client), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.title) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____title), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Size) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Size), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.resulation) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____resulation), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            


                          if (_GPN(x => x.Photographer) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Photographer), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.pictype) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____pictype), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.picformat) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____picformat), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            
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
                    
            if (Dic.ContainsKey(_GPN(x => x.client.id).ToClientDsFieldName()))
            {
                try
                {
                    this.client= ModelRepositories.Bases.Character_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.client.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.client), ref Dic);

                }
                catch { }
            }
                    
            if (Dic.ContainsKey(_GPN(x => x.title.id).ToClientDsFieldName()))
            {
                try
                {
                    this.title= ModelRepositories.jah.Title_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.title.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.title), ref Dic);

                }
                catch { }
            }
                    
            if (Dic.ContainsKey(_GPN(x => x.Size.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Size= ModelRepositories.jah.Size_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.Size.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.Size), ref Dic);

                }
                catch { }
            }
                    
            if (Dic.ContainsKey(_GPN(x => x.resulation.id).ToClientDsFieldName()))
            {
                try
                {
                    this.resulation= ModelRepositories.jah.Resulation_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.resulation.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.resulation), ref Dic);

                }
                catch { }
            }
                    
            if (Dic.ContainsKey(_GPN(x => x.Photographer.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Photographer= ModelRepositories.Bases.Character_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.Photographer.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.Photographer), ref Dic);

                }
                catch { }
            }
                    
            if (Dic.ContainsKey(_GPN(x => x.pictype.id).ToClientDsFieldName()))
            {
                try
                {
                    this.pictype= ModelRepositories.jah.PictureType_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.pictype.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.pictype), ref Dic);

                }
                catch { }
            }
                    
            if (Dic.ContainsKey(_GPN(x => x.picformat.id).ToClientDsFieldName()))
            {
                try
                {
                    this.picformat= ModelRepositories.jah.PictureFormat_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.picformat.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.picformat), ref Dic);

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
                return ModelRepositories.jah.Picture_Repository.ByPK((Guid)primarykeys_value[_GPN(x => x.id)]);
            }
            return null;

            }}
public class PictureLog: LogModelBase<PictureLog>
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

public virtual string piccode { get; set; }

public virtual string shotdate { get; set; }


                                            LoadableVar<Character> _client= new LoadableVar<Character>();
                                            public virtual Character _____client { get; set; }
                                            public virtual Character client
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Character, Guid>
                                                        (ref _client,
                                                        x => x._____client,
                                                        ModelRepositories.Bases.Character_Repository.ByPK,
                                                        x => x._____client.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.client, x => x._____client, _client, value);

                                                }
                                            }
                                    

                                            LoadableVar<Title> _title= new LoadableVar<Title>();
                                            public virtual Title _____title { get; set; }
                                            public virtual Title title
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Title, Guid>
                                                        (ref _title,
                                                        x => x._____title,
                                                        ModelRepositories.jah.Title_Repository.ByPK,
                                                        x => x._____title.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.title, x => x._____title, _title, value);

                                                }
                                            }
                                    

                                            LoadableVar<Size> _Size= new LoadableVar<Size>();
                                            public virtual Size _____Size { get; set; }
                                            public virtual Size Size
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Size, Guid>
                                                        (ref _Size,
                                                        x => x._____Size,
                                                        ModelRepositories.jah.Size_Repository.ByPK,
                                                        x => x._____Size.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.Size, x => x._____Size, _Size, value);

                                                }
                                            }
                                    

                                            LoadableVar<Resulation> _resulation= new LoadableVar<Resulation>();
                                            public virtual Resulation _____resulation { get; set; }
                                            public virtual Resulation resulation
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Resulation, Guid>
                                                        (ref _resulation,
                                                        x => x._____resulation,
                                                        ModelRepositories.jah.Resulation_Repository.ByPK,
                                                        x => x._____resulation.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.resulation, x => x._____resulation, _resulation, value);

                                                }
                                            }
                                    
public virtual string Location { get; set; }


                                            LoadableVar<Character> _Photographer= new LoadableVar<Character>();
                                            public virtual Character _____Photographer { get; set; }
                                            public virtual Character Photographer
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Character, Guid>
                                                        (ref _Photographer,
                                                        x => x._____Photographer,
                                                        ModelRepositories.Bases.Character_Repository.ByPK,
                                                        x => x._____Photographer.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.Photographer, x => x._____Photographer, _Photographer, value);

                                                }
                                            }
                                    

                                            LoadableVar<PictureType> _pictype= new LoadableVar<PictureType>();
                                            public virtual PictureType _____pictype { get; set; }
                                            public virtual PictureType pictype
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<PictureType, Guid>
                                                        (ref _pictype,
                                                        x => x._____pictype,
                                                        ModelRepositories.jah.PictureType_Repository.ByPK,
                                                        x => x._____pictype.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.pictype, x => x._____pictype, _pictype, value);

                                                }
                                            }
                                    

                                            LoadableVar<PictureFormat> _picformat= new LoadableVar<PictureFormat>();
                                            public virtual PictureFormat _____picformat { get; set; }
                                            public virtual PictureFormat picformat
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<PictureFormat, Guid>
                                                        (ref _picformat,
                                                        x => x._____picformat,
                                                        ModelRepositories.jah.PictureFormat_Repository.ByPK,
                                                        x => x._____picformat.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.picformat, x => x._____picformat, _picformat, value);

                                                }
                                            }
                                    
}
}

