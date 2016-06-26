package org.fertilizerplant.qrcodemangement.service;

import java.io.File;

public interface QrCodeGenerationService {
	
    static String DEFAULT_OUTPUT_FOLDER = "data/images";

	public void generateQrCode(final String outputFilePath, final String textToBeEncoded, final String fileType,
			final int size);
}
