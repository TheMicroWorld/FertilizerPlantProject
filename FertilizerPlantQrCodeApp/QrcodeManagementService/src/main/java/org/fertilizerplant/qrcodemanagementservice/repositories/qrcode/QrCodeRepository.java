package org.fertilizerplant.qrcodemanagementservice.repositories.qrcode;

import org.fertilizerplant.qrcodemanagementservice.models.QrCode;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.querydsl.QueryDslPredicateExecutor;
import org.springframework.stereotype.Repository;

@Repository
public interface QrCodeRepository extends JpaRepository<QrCode,Long>,QueryDslPredicateExecutor<QrCode>{

}
