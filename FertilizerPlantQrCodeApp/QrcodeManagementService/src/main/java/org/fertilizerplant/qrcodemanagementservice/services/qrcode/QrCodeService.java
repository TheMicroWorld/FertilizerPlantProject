package org.fertilizerplant.qrcodemanagementservice.services.qrcode;

import java.util.List;

import org.fertilizerplant.qrcodemanagementservice.models.QrCode;

public interface QrCodeService {
	
	List<QrCode> getAllQrCodes();
    QrCode save(QrCode qrCode);
}
