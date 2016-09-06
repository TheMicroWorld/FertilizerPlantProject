package org.fertilizerplant.usermangementservice.services.distributors.impl;

import java.util.ArrayList;
import java.util.List;

import org.fertilizerplant.common.synchronization.download.BaseSyncDataRecv;
import org.fertilizerplant.usermangementservice.models.distributors.Distributor;
import org.fertilizerplant.usermangementservice.models.distributors.QDistributor;
import org.fertilizerplant.usermangementservice.repositories.distributors.DistributorRepository;
import org.fertilizerplant.usermangementservice.services.distributors.DistributorService;
import org.fertilizerplant.usermangementservice.services.users.impl.DefaultUserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.mysema.query.types.Predicate;


@Service
@Qualifier("distributorService")
public class DefaultDistributorService extends DefaultUserService implements DistributorService
{
	@Autowired
	private DistributorRepository distributorRepository;
	
	public List<Distributor> getAllDistributors()
	{
		List<Distributor> distributors = distributorRepository.findAll();
		return distributors;
	}
	
	@Transactional
    public void updateDistributorsSyncStatus(List<BaseSyncDataRecv> dataReceived)
    {
    	List<Distributor> distributors = new ArrayList<Distributor>();
		for(BaseSyncDataRecv data : dataReceived)
		{
			Distributor distributor = distributorRepository.findOne(data.getId());
			distributor.setSyncStatus(data.isSyncStatus());
			distributors.add(distributor);
		}
		distributorRepository.bulkSave(distributors);
    }

	public List<Distributor> getAllUnSynchedDistributor()
	{
		QDistributor distributor = QDistributor.distributor;
		Predicate distributorUnsynched = distributor.syncStatus.eq(false);
		return (List<Distributor>) distributorRepository.findAll(distributorUnsynched);
	}

	@Override
	public Distributor findDistributorById(String distributorId) {
		
		return distributorRepository.findOne(distributorId);
	}
}
