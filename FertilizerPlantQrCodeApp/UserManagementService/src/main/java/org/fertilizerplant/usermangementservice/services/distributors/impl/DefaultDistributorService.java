package org.fertilizerplant.usermangementservice.services.distributors.impl;

import java.util.List;

import org.fertilizerplant.usermangementservice.models.distributors.Distributor;
import org.fertilizerplant.usermangementservice.repositories.distributors.DistributorRepository;
import org.fertilizerplant.usermangementservice.services.distributors.DistributorService;
import org.fertilizerplant.usermangementservice.services.users.impl.DefaultUserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Service;

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
}
