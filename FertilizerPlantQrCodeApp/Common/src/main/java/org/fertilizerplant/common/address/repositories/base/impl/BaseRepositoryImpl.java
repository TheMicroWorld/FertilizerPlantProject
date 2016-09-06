package org.fertilizerplant.common.address.repositories.base.impl;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import org.fertilizerplant.common.address.repositories.base.BaseRepository;
import org.springframework.beans.factory.annotation.Value;

public class BaseRepositoryImpl<T> implements BaseRepository<T>{
	
	@PersistenceContext
	private EntityManager entityManager;
	 
	@Value("${spring.jpa.properties.hibernate.jdbc.batch_size}")
	private int batchSize;
	
	public Collection<T> bulkSave(Collection<T> entities)
	{
		  final List<T> savedEntities = new ArrayList<T>(entities.size());
		  int i = 0;
		  for (T t : entities) 
		  {
		    savedEntities.add(persistOrMerge(t));
		    i++;
		    if (i % batchSize == 0) {
		      // Flush a batch of inserts and release memory.
		      entityManager.flush();
		      entityManager.clear();
		    }
		  }
		  return savedEntities;
		}
		 
		private T persistOrMerge(T entity) 
		{
		  if (entity != null)
		  {
		    entityManager.merge(entity);
		    return entity;
		  }
		  else
		  {
		    return entityManager.merge(entity);
		  }
		}
}
