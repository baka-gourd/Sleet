/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Claim } from './Claim';

export type User = {
    id?: string;
    name?: string | null;
    claims?: Array<Claim> | null;
}