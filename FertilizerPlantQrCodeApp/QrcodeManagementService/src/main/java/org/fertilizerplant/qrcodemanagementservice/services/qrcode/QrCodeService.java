package org.fertilizerplant.qrcodemanagementservice.services.qrcode;

import java.util.List;

import org.fertilizerplant.qrcodemanagementservice.models.QrCode;

import com.mysema.query.types.Predicate;

public interface QrCodeService {
	
	List<QrCode> getAllQrCodes();
    QrCode save(QrCode qrCode);
    List<String> getAllQrCodeValues();
    void generateQrCodes(int number,String webrootPath);
}
