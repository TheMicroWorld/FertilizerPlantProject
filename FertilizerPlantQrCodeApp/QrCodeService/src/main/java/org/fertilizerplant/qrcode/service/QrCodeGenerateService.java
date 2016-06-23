package org.fertilizerplant.qrcode.service;

import java.io.File;

public interface QrCodeGenerateService {

	public void generateQrCode(final String outputFilePath, final String textToBeEncoded, final String fileType,
			final int size);
}
