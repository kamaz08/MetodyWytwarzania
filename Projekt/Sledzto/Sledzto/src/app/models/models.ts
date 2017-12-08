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

export interface WebsiteMenu {
    Id: Number,
    Name: String,
    Url: String,
    OptionList: OptionShort[]
}

export interface OptionShort {
    Id: Number,
    Technique : Number
}

export interface History {
    Message: String,
    DateTime: String
}