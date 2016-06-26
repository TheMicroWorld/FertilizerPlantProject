package org.fertilizerplant.core.persistence;

public interface ModelService {	
	public void save(Object target);
	public void create(Object target);
	public void update(Object target);
	public void delete(Object target);
}
