import { Neighborhood } from "../neighborhood/neighborhood.model";

//find drugstore
export interface RequestDrugstore {    
    name: string;
    maxResults: number;
}
export interface ResponseDrugstores {
    id: string;
    name: string;
    roundTheClock: boolean;
    foundationDate: Date;
    neighborhoodId: string;
    maxResults: number;
}

//create drugstore
export interface RequestCreateDrugstore {
    name: string;
    roundTheClock: boolean;
    foundationDate: Date;
    neighborhoodId: string;
}
export interface ResponseCreateDrugstore {
    id: string;
    name: string;
    roundTheClock: boolean;
    foundationDate: Date;
    neighborhoodId: string;
}

//update drugstore
export interface RequestUpdateDrugstore {
    id: string;
    name: string;
    roundTheClock: boolean;
    foundationDate: Date;
    neighborhoodId: string;
}
export interface ResponseUpdateDrugstore {
    id: string;
    name: string;
    roundTheClock: boolean;
    foundationDate: Date;
    neighborhoodId: string;
}