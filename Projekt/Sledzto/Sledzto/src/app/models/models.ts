export interface Website {
    Id: Number,
    Name: String,
    Url: String
}

export interface Option {
    Id: Number,
    WebsiteId: Number,
    TrackigTechnique: Number,
    Options: String,
    Frequency: Number,
    OneTime: boolean
}