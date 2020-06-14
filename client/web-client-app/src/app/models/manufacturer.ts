export interface IProduct {
    id: string,
    name: string,
    description: string,
    category: string,
    price: string,
    oldPrice: string,
    imageUrl: string,
    // city: string,
    photos: IPhoto[],
    comments: IComment[],
}

export interface IPhoto {
    id: string,
    url: string,
    isMain: boolean
}

export interface IComment {
    id: string;
    createdAt: Date;
    body: string;
    username: string;
    displayName: string;
    image: string;
}  