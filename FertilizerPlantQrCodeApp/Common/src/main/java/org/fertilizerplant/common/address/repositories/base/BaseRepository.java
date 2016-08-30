package org.fertilizerplant.common.address.repositories.base;

import java.util.Collection;

/**
 * This is the base repository which might contain other methods.But here it contains bulk save
 * @author nogrethumphrey
 *
 * @param <T>
 */
public interface BaseRepository<T> {	
	Collection<T> bulkSave(Collection<T> entities);
}
