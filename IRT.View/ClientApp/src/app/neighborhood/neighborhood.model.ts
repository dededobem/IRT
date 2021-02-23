export interface Neighborhood {    
    id: string;
    name: string;
    max_results: number;
}

export interface ResponseNeighborhoods {
    page: number;
    per_page: number;
    total: number;
    total_pages: number;
    data: Neighborhood[];
}

export interface RequestCreate {
    name: string;
}

export interface ResponseCreate {
    id: string;
    name: string;
}

