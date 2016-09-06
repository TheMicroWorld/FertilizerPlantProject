package org.fertilizerplant.common.base.models;

import javax.persistence.Column;
import javax.persistence.MappedSuperclass;

import org.codehaus.jackson.annotate.JsonIgnore;
import org.hibernate.annotations.Type;

@MappedSuperclass
public class BaseEntity {
	
	@Column(name="syncStatus")
	@Type(type="yes_no")
	private boolean syncStatus;

	@JsonIgnore
	public boolean isSyncStatus() {
		return syncStatus;
	}

	public void setSyncStatus(boolean syncStatus) {
		this.syncStatus = syncStatus;
	}
	
}
