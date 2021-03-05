//find neighborhood
export interface RequestNeighborhood {    
    name: string;
    maxResults: number;
}
export interface ResponseNeighborhoods {
    data: Neighborhood[];
}

//list all
export interface Neighborhood {
    id: string;
    name: string;
}

//create neighborhood
export interface RequestCreate {
    name: string;
}
export interface ResponseCreate {
    id: string;
    name: string;
}

