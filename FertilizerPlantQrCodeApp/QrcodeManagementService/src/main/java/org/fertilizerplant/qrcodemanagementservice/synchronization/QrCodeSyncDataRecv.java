package org.fertilizerplant.qrcodemanagementservice.synchronization;

import org.fertilizerplant.common.synchronization.download.BaseSyncDataRecv;

public class QrCodeSyncDataRecv extends BaseSyncDataRecv
{
    private String distributorId;
    
    private String productId;
    
	public String getDistributorId() {
		return distributorId;
	}
	public void setDistributorId(String distributorId) {
		this.distributorId = distributorId;
	}
	public String getProductId() {
		return productId;
	}
	public void setProductId(String productId) {
		this.productId = productId;
	}
    
    
}
