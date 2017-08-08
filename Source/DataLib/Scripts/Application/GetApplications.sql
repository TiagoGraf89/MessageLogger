select 
    application_id 
    , display_name
    , secret
from [application]
where (@Application_Id is null or application_id = @Application_Id);
