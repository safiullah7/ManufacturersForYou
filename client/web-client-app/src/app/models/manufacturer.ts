export interface IManufacturersEnvelope {
    manufacturers: IManufacturer[],
    manufacturersCount: number
}

export interface IManufacturer {
    id: string,
    name: string,
    city: string,
    category: string,
    imageUrl: string,
    productsCount: number,
    products: IProduct[]
}

export interface IProduct {
    id: string,
    name: string,
    description: string,
    category: string,
    price: number,
    oldPrice: number,
    imageUrl: string,
    // city: string,
    photos: IPhoto[],
    features: IFeature[],
    comments: IComment[]
}

export interface IPhoto {
    id: string,
    url: string,
    isMain: boolean
}

export interface IFeature {
    key: string,
    value: string
}

export interface IComment {
    id: string;
    createdAt: Date;
    body: string;
    username: string;
    displayName: string;
    image: string;
}  