select 
	application_id , token, createdon, expireson
from [token]
where token = @token;
