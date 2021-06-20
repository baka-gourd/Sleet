/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Component } from './Component';

export type Project = {
    id?: string;
    name?: string | null;
    components?: Array<Component> | null;
}