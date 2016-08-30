package org.fertilizerplant.usermangementservice.services.distributors;

import java.util.List;

import org.fertilizerplant.usermangementservice.models.distributors.Distributor;
import org.fertilizerplant.usermangementservice.services.users.UserService;

public interface DistributorService extends UserService
{
	List<Distributor> getAllDistributors();
}
