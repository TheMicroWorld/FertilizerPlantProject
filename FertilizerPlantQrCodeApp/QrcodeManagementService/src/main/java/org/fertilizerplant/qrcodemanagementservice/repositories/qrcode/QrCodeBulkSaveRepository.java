package org.fertilizerplant.qrcodemanagementservice.repositories.qrcode;

import java.util.Collection;

public interface QrCodeBulkSaveRepository<T>  {
	Collection<T> bulkSave(Collection<T> entities);
}
