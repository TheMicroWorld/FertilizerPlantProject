package org.fertilizerplant.common.synchronization.download;

/**
 * 
 * @author nogrethumphrey
 *
 */
public class BaseSyncDataRecv {
	private String id;
	private boolean syncStatus;
	
	public String getId() {
		return id;
	}
	
	public void setId(String id) {
		this.id = id;
	}

	public boolean isSyncStatus() {
		return syncStatus;
	}

	public void setSyncStatus(boolean syncStatus) {
		this.syncStatus = syncStatus;
	}
}
