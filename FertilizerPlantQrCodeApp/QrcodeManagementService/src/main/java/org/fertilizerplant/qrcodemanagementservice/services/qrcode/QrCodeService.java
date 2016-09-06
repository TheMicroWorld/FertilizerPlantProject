package org.fertilizerplant.qrcodemanagementservice.services.qrcode;

import java.util.List;

import org.fertilizerplant.qrcodemanagementservice.models.QrCode;
import org.fertilizerplant.qrcodemanagementservice.synchronization.QrCodeSyncDataRecv;

public interface QrCodeService {
	
	List<QrCode> getAllQrCodes();
	QrCode getQrCodeById(String qrCodeId);
    QrCode save(QrCode qrCode);
    List<String> getAllQrCodeValues();
    void generateQrCodes(int number,String webrootPath);
    void updateQrCodesSyncStatusAndBindingInfo(List<QrCodeSyncDataRecv> dataReceived);
	List<QrCode> getAllUnSynchedQrCodes();
}
